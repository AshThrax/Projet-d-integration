using AutoMapper;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.Common.Interfaces.IService;
using ProjecIntegration.Api.Application.DTO;
using ProjecIntegration.Api.Models.BaseEntity;

namespace ProjecIntegration.Api.Infrastructure.Service
{
    /// <summary>
    /// classe de service générique capable d'implmenter les methods crud et de les mapper selon leur Dto
    /// </summary>
    /// <typeparam name="T">mon entity / Models</typeparam>
    /// <typeparam name="U">le dto de mon application</typeparam>
    public class GeneriqueService<T,U> : IGeneriqueService<T,U> 
        where T : BaseEntity where U : BaseDto
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        public GeneriqueService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<U> Add(U entity)
        {
            var ent = _mapper.Map<U,T>(entity);
           _repository.Insert(ent);
            return await GetById(ent.Id);
        }

        public void Delete(U entity)
        {
            var del = _mapper.Map<U,T>(entity);
           _repository.Delete(del);
        }

        public async Task<IEnumerable<U>> GetAll()
        {
           var getEntities =await _repository.GetAll();
           var entities=  _mapper.Map< IEnumerable<T>,IEnumerable<U>>(getEntities);
           return entities;
        }

        public async Task<U> GetById(int id)
        {
           var GetEntity = await _repository.GetById(id);
           var entity = _mapper.Map<T,U>(GetEntity);
           return entity;
        }

        public async Task<U> Update(U entity)
        {
            var mapEntity = _mapper.Map<U, T>(entity);
             _repository.Update(mapEntity);
            var getEnt= await GetById(entity.Id);
            return  getEnt;
        }
    }
}
