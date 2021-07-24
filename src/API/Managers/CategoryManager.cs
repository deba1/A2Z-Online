using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface ICategoryManager : IBaseManager<Category>
    {

    }
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
