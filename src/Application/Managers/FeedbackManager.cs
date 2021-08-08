using Domain.Entities;
using Application.Repositories;
using AutoMapper;

namespace Application.Managers
{
    public interface IFeedbackManager : IBaseManager<Feedback>
    {

    }

    public class FeedbackManager : BaseManager<Feedback>, IFeedbackManager
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackManager(IFeedbackRepository feedbackRepositoy, IMapper mapper) : base(feedbackRepositoy, mapper)
        {
            _feedbackRepository = feedbackRepositoy;
        }
    }
}

