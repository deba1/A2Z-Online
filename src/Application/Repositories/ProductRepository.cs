using Application.Interfaces;
using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Feedback>> GetAllFeedbacksProducts(int productId);
        Task<Feedback> GetFeedbacksByProductId(int productId, int feedbackId);

    }

    class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IAppDbContext _context;

        public ProductRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }

        #region Feedback

        public async Task<List<Feedback>> GetAllFeedbacksProducts(int tOneId)
        {
            return await _context.Feedbacks.Where(x => x.ProductId.Equals(tOneId))
                .Include(p => p.User).ToListAsync();
        }

        public async Task<Feedback> GetFeedbacksByProductId(int tOneId, int tTwoId)
        {
            return await _context.Feedbacks.Where(x => x.ProductId.Equals(tOneId) && x.Id.Equals(tTwoId))
                .Include(p => p.User).FirstOrDefaultAsync();
        }

        #endregion
    }
}
