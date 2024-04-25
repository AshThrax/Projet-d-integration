using Application.Common.Repository;
using Application.DTO;
using AutoMapper;
using Domain.DataType;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.businessService
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
          if(addAnnonceDto != null)
            {
                 _annonceRepository.Insert(_mapper.Map<Annonce>(addAnnonceDto));
            }
        }

        public async Task DeleteAnnonce(string annonceId)
        {
           var annonce= _annonceRepository.GetById(annonceId);
            if(annonce != null)
            {
                _annonceRepository.Delete(annonceId);
            }
        }

        public async  Task<GetAnnonceDto> GetAnnonceById(string annonceId)
        {
            var annonce = await _annonceRepository.GetById(annonceId);
            if (annonce != null)
            {
                var mapped = _mapper.Map<GetAnnonceDto>(annonce);
                return mapped;
            }
            return null; 
        }

        public Task<Pagination<GetAnnonceDto>> GetAnnonces()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAnnonce(string annonceId,UpdateAnnonceDto annonceDto)
        {
            var annonce = await _annonceRepository.GetById(annonceId);
            if (annonce != null)
            {
                var mapped= _mapper.Map<Annonce>(annonceDto);
                _annonceRepository.Update(annonceId, mapped);
            }
        }
    }
}
