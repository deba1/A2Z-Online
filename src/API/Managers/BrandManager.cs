using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IBrandManager : IBaseManager<Brand>
    {
    }

    public class BrandManager : BaseManager<Brand>, IBrandManager
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository) : base(brandRepository)
        {
            _brandRepository = brandRepository;
        }
    }
}
