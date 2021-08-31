using Domain.Common;
using Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Managers
{
    public interface IBaseManager<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add<DTOType>(DTOType entity);
        Task<int> Update<DTOType>(T entity, DTOType dtoEntity);
        Task<int> Remove(T entity);
    }

    public class BaseManager<T> : IBaseManager<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        private readonly IMapper _mapper;

        public BaseManager(IBaseRepository<T> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async virtual Task<T> Add<DTOType>(DTOType dtoEntity)
        {
            T entity = _mapper.Map<T>(dtoEntity);
            await _baseRepository.Add(entity);
            return entity;
        }

        public async virtual Task<List<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _baseRepository.GetById(id);
        }

        public async virtual Task<int> Remove(T entity)
        {
            return await _baseRepository.Remove(entity);
        }

        public async virtual Task<int> Update<DTOType>(T entity, DTOType dtoEntity)
        {
            entity = _mapper.Map(dtoEntity, entity);
            return await _baseRepository.Update(entity);
        }
    }
}
