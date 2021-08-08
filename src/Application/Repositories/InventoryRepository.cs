using Application.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {

    }

    class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        private readonly IAppDbContext _context;

        public InventoryRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
