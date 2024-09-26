
using ApplicationUser.Common.Repository;
using ApplicationUser.Dto;
using ApplicationUser.Service;
using AutoMapper;

using Domain.Entity;
using Domain.ServiceResponse;

namespace InfrastructureUser.Service
{
    public class Service<TEntity,TDto,TAddDto,TUpdateDto> :IService<TEntity, TDto,TAddDto, TUpdateDto>
        where TEntity : BaseEntity
        where TDto : BasicDto
        where TAddDto : AddBaseDto
        where TUpdateDto : UpdateUserDetailDto
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public Service(IRepository<TEntity> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TDto>> AddAsync(TAddDto entity)
        {
            ServiceResponse<TDto> response = new();
            try
            {
                TEntity AddEntity= _mapper.Map<TEntity>(entity);
                AddEntity.CreatedDate = DateTime.Now;
                await  _repository.Insert(AddEntity);

                response.Success = true;
                response.Message = "the data Have been Succesfully added to the Data base";
                return response;
            }
            catch (Exception)
            {
                response.Message = "an Error occured while adding Data";
                response.Errortype= Domain.Enum.Errortype.Bad;
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<TDto>> DeleteAsync(int entityId)
        {
            ServiceResponse<TDto> response = new();
            try
            {
                await _repository.Delete(entityId);
                response.Success = true;
                response.Message = "the data Have been Succesfully added to the Data base";
                return response;
            }
            catch (Exception)
            {
                response.Message = "an Error occured while adding Data";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<TDto>>> GetAsync()
        {
            ServiceResponse<List<TDto>> response = new();
            try
            {
                IEnumerable<TEntity> getEntitites = await _repository.GetAll();

                response.Data = _mapper.Map<List<TDto>>(getEntitites.ToList());
                response.Success = true;
                response.Message = "the data Have been Succesfully added to the Data base";
                return response;
            }
            catch (Exception)
            {
                response.Message = "an Error occured while adding Data";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<TDto>> GetByIdAsync(int id)
        {
            ServiceResponse<TDto> response = new();
            try
            {
                TEntity getEntity = await _repository.GetById(id);
                if (getEntity != null)
                {
                    throw new ArgumentNullException("Bad Argument passed to the application");
                }
                response.Data = _mapper.Map<TDto>(getEntity);
                response.Success = true;
                response.Message = "the data Have been Succesfully retrieved to the Data base";
                return response;
            }
            catch (Exception)
            {
                response.Message = "an Error occured while adding Data";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<TDto>> UpdateAsync(int Id,TUpdateDto entity)
        {
            ServiceResponse<TDto> response = new();
            try
            {
                TEntity UpdateEntity = _mapper.Map<TEntity>(entity);
                UpdateEntity.UpdatedDate = DateTime.Now;
                await _repository.Update(Id,UpdateEntity);
                response.Success = true;
                response.Message = "the data Have been Succesfully Updated to the Data base";
                return response;
            }
            catch (Exception)
            {
                response.Message = "an Error occured while adding Data";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Success = false;
                return response;
            }
        }
    }
}
