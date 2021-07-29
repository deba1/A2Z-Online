using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IFeedbackManager : IBaseManager<Feedback>
    {

    }

    public class FeedbackManager : BaseManager<Feedback>, IFeedbackManager
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackManager(IFeedbackRepository feedbackRepositoy) : base(feedbackRepositoy)
        {
            _feedbackRepository = feedbackRepositoy;
        }
    }
}

