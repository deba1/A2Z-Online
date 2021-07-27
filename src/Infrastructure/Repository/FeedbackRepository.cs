using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {

    }
    class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        private readonly AppDbContext _context;

    public FeedbackRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
