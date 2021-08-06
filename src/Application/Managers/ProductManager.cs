using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IProductManager : IBaseManager<Product>
    {

    }

    class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
        }
    }
}
