using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface ICategoryManager : IBaseManager<Category>
    {
        Task<ICollection<Product>> GetAllCategoryProducts(int categoryId);
        Task<Product> GetCategoryProductById(int categoryId, int productId);
    }

    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBaseSecondLevelRepository<Category, Product> _categoryProductRepository;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IBaseSecondLevelRepository<Category, Product> categoryProductRepository) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryProductRepository = categoryProductRepository;
        }

        #region Product

        public async Task<ICollection<Product>> GetAllCategoryProducts(int categoryId)
        {
            return await _categoryProductRepository.GetAllSecondLevel(categoryId, "CategoryId");
        }

        public async Task<Product> GetCategoryProductById(int categoryId, int productId)
        {
            return await _categoryProductRepository.GetSecondLevelById(categoryId, productId, "CategoryId");
        }

        #endregion
    }
}
