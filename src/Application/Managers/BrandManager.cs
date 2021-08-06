using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IBrandManager : IBaseManager<Brand>
    {

    }

    public class BrandManager : BaseManager<Brand>, IBrandManager
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository, IMapper mapper) : base(brandRepository, mapper)
        {
            _brandRepository = brandRepository;
        }
    }
}
