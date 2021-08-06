using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface ICategoryManager : IBaseManager<Category>
    {

    }
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
