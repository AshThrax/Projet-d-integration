using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

namespace DataInfraTheather.BusinessService
{

    public class BusinessComplexe : IBusinessComplexe
    {
        private readonly IMapper _mapper;
        private readonly IComplexeRepository _complexeRepository;

        public BusinessComplexe(IMapper mapper, IComplexeRepository complexeRepository)
        {
            _mapper = mapper;
            _complexeRepository = complexeRepository;
        }

        public void CreateAsync(ComplexeDto complexeDto)
        {
            try
            {
                var entity = _mapper.Map<Complexe>(complexeDto);
                _complexeRepository.Insert(entity);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                var getEntity = await _complexeRepository.GetById(id);
                if (getEntity != null)
                {
                   await _complexeRepository.Delete(id);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ComplexeDto>> GetAllComplexe()
        {
            try
            {
                var GetEntity = await _complexeRepository.GetAll();
                return _mapper.Map<IEnumerable<ComplexeDto>>(GetEntity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ComplexeDto> GetComplexe(int id)
        {
            try
            {
                var GetEntity = await _complexeRepository.GetById(id);
                return _mapper.Map<ComplexeDto>(GetEntity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(int id, UpdateComplexeDto complexeDto)
        {
            try
            {
                var getEntity = await _complexeRepository.GetById(id);
                if (getEntity != null)
                {
                    var conversion = _mapper.Map<Complexe>(getEntity);
                   _complexeRepository.Update(id, conversion);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
