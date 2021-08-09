using Application.Interfaces;
using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {

    }
    class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        private readonly IAppDbContext _context;

        public FeedbackRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
