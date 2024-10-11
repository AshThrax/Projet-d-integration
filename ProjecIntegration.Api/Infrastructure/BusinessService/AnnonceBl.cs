using ApplicationAnnonce.Common.businessService;
using ApplicationAnnonce.Common.Repository;
using ApplicationAnnonce.DTO;
using AutoMapper;
using Domain.DataType;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureAnnonce.BusinessService
{
    public class AnnonceBl : IAnnonceBl
    {
        private readonly IAnnonceRepository _annonceRepository;
        private IMapper _mapper;

        public AnnonceBl(IAnnonceRepository annonceRepository, IMapper mapper)
        {
            _annonceRepository = annonceRepository;
            _mapper = mapper;
        }

        public async Task CreateAnnonce(AddAnnonceDto addAnnonceDto)
        {
            try
            {
                if (addAnnonceDto != null)
                {
                    Annonce createAnnonce = _mapper.Map<Annonce>(addAnnonceDto);
                    createAnnonce.CreatedDate = DateTime.Now;
                   await _annonceRepository.Insert(createAnnonce);
                }

            }
            catch (Exception)
            {


            }
        }

        public async Task DeleteAnnonce(string annonceId)
        {
            try
            {
                Annonce annonce = await _annonceRepository.GetById(annonceId);
                if (annonce != null)
                {
                    await _annonceRepository.Delete(annonceId);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<GetAnnonceDto> GetAnnonceById(string annonceId)
        {
            try
            {
                Annonce annonce = await _annonceRepository.GetById(annonceId);
                if (annonce != null)
                {
                    GetAnnonceDto mapped = _mapper.Map<GetAnnonceDto>(annonce);
                    return mapped;
                }
                return new GetAnnonceDto();
            }
            catch (Exception)
            {

                return new GetAnnonceDto();
            }

        }

        public async Task<Pagination<GetAnnonceDto>> GetAnnonces(int pageNumber)
        {
            try
            {
                IEnumerable<Annonce> getAllAnnonce = (await _annonceRepository.GetAll()).OrderByDescending(x=>x.CreatedDate);
                return Pagination<GetAnnonceDto>.ToPagedList(_mapper.Map<List<GetAnnonceDto>>(getAllAnnonce.ToList()), pageNumber, 10);

            }
            catch (Exception)
            {

                return Pagination<GetAnnonceDto>.ToPagedList(new List<GetAnnonceDto>(), pageNumber, 10);
            }

        }

        public async Task UpdateAnnonce(string annonceId, UpdateAnnonceDto annonceDto)
        {
            try
            {
                Annonce annonce = await _annonceRepository.GetById(annonceId);
                if (annonce != null)
                {
                    Annonce mapped = _mapper.Map<Annonce>(annonceDto);
                    mapped.UpdatedDate = DateTime.Now;
                    await _annonceRepository.Update(annonceId, mapped);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
