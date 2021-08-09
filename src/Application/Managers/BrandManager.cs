using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface IBrandManager : IBaseManager<Brand>
    {
        Task<ICollection<Product>> GetAllBrandProduct(int brandId);
        Task<Product> GetBrandProductById(int brandId, int productId);
    }

    public class BrandManager : BaseManager<Brand>, IBrandManager
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBaseSecondLevelRepository<Brand, Product> _brandProductRepository;

        public BrandManager(IBrandRepository brandRepository, IMapper mapper, IBaseSecondLevelRepository<Brand, Product> brandProductRepository) : base(brandRepository, mapper)
        {
            _brandRepository = brandRepository;
            _brandProductRepository = brandProductRepository;
        }

        #region Product
        public async Task<ICollection<Product>> GetAllBrandProduct(int brandId)
        {
            return await _brandProductRepository.GetAllSecondLevel(brandId, "BrandId");
        }

        public async Task<Product> GetBrandProductById(int brandId, int productId)
        {
            return await _brandProductRepository.GetSecondLevelById(brandId, productId, "BrandId");
        }
        #endregion

    }
}
