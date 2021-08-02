using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IGlobalConfigurationManager : IBaseManager<GlobalConfiguration>
    {

    }

    class GlobalConfigurationManager : BaseManager<GlobalConfiguration>, IGlobalConfigurationManager
    {
        private readonly IGlobalConfigurationRepository _globalConfigurationRepository;

        public GlobalConfigurationManager(IGlobalConfigurationRepository globalConfigurationRepository) : base(globalConfigurationRepository)
        {
            _globalConfigurationRepository = globalConfigurationRepository;
        }
    }
}
