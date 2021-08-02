using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IProductManager : IBaseManager<Product>
    {

    }

    class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

    }
}
