using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

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

        public async Task<ServiceResponse<ComplexeDto>> CreateAsync(AddComplexeDto complexeDto)
        {
            ServiceResponse<ComplexeDto> response = new();
            try
            {
                var entity = _mapper.Map<Complexe>(complexeDto);
                entity.CreatedDate = DateTime.Now;
                await _complexeRepository.Insert(entity);

                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'operation";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ComplexeDto>> Delete(int id)
        {
            ServiceResponse<ComplexeDto> response = new();
            try
            {
                var getEntity = await _complexeRepository.GetById(id);
                if (getEntity != null)
                {
                   await _complexeRepository.Delete(id);
                    response.Success = true;
                    response.Message = "opération réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'operation";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ComplexeDto>>> GetAllComplexe()
        {
            ServiceResponse<IEnumerable<ComplexeDto>> response = new();
            try
            {
                var GetEntity = await _complexeRepository.GetAll();
                response.Data=_mapper.Map<IEnumerable<ComplexeDto>>(GetEntity);
                response.Success=true;
                response.Message = "opération réussi";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'operation";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ComplexeDto>> GetComplexe(int id)
        {
            ServiceResponse < ComplexeDto >response = new();
            try
            {
                var GetEntity = await _complexeRepository.GetById(id,c=>c.SalleDeTheatres);
                response.Data= _mapper.Map<ComplexeDto>(GetEntity);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'operation";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ComplexeDto>> UpdateAsync(int id, UpdateComplexeDto complexeDto)
        {
            ServiceResponse<ComplexeDto> response = new();
            try
            {
                var getEntity = await _complexeRepository.GetById(id);
                if (getEntity != null)
                {
                    Complexe conversion = _mapper.Map<Complexe>(getEntity);
                    conversion.UpdatedDate=DateTime.Now;
                    await _complexeRepository.Update(id, conversion);
                    
                    response.Success = true;
                    response.Message = "operation réussi";
                    response.Errortype =Domain.Enum.Errortype.Good;
       
                }

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
