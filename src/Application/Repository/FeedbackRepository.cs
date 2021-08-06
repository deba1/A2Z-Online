using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {

    }
    class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        private readonly DbContext _context;

        public FeedbackRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
