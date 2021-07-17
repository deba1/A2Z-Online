using Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Managers
{
    public interface IBaseManager<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Remove(T entity);
    }

    public class BaseManager<T> : IBaseManager<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async virtual Task<int> Add(T entity)
        {
            return await _baseRepository.Add(entity);
        }

        public async virtual Task<ICollection<T>> GetAll()
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

        public async virtual Task<int> Update(T entity)
        {
            return await _baseRepository.Update(entity);
        }
    }
}
