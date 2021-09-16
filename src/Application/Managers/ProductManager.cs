using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface IProductManager : IBaseManager<Product>
    {
        Task<List<Feedback>> GetAllFeedbacksProducts(int productId);
        Task<Feedback> GetFeedbacksByProductId(int productId, int feedbackId);
        Task<List<Inventory>> GetAllInventorys(int productId);
        Task<Inventory> GetProductInventoryById(int productId, int inventoryId);
    }

    class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IBaseSecondLevelRepository<Product, Inventory> _productInventoryRepository;


        public ProductManager(IProductRepository productRepository, IMapper mapper, IBaseSecondLevelRepository<Product, Inventory> productInventoryRepository) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _productInventoryRepository = productInventoryRepository;
        }

        #region Feedback

        public async Task<List<Feedback>> GetAllFeedbacksProducts(int productId)
        {
            return await _productRepository.GetAllFeedbacksProducts(productId);
        }

        public async Task<Feedback> GetFeedbacksByProductId(int productId, int feedbackId)
        {
            return await _productRepository.GetFeedbacksByProductId(productId, feedbackId);
        }

        #endregion

        #region Inventory

        public async Task<List<Inventory>> GetAllInventorys(int productId)
        {
            return await _productInventoryRepository.GetAllSecondLevel(productId, "ProductId");
        }

        public async Task<Inventory> GetProductInventoryById(int productId, int inventoryId)
        {
            return await _productInventoryRepository.GetSecondLevelById(productId, inventoryId, "ProductId");
        }

        #endregion
    }
}
