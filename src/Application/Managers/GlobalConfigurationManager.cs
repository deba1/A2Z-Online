using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IGlobalConfigurationManager : IBaseManager<GlobalConfiguration>
    {

    }

    class GlobalConfigurationManager : BaseManager<GlobalConfiguration>, IGlobalConfigurationManager
    {
        private readonly IGlobalConfigurationRepository _globalConfigurationRepository;

        public GlobalConfigurationManager(
                IGlobalConfigurationRepository globalConfigurationRepository,
                IMapper mapper
            )
            : base(globalConfigurationRepository, mapper)
        {
            _globalConfigurationRepository = globalConfigurationRepository;
        }
    }
}
