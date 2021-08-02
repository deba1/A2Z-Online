using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {

    }

    class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
