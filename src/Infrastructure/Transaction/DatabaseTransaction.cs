using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Transaction
{
    public interface IDatabaseTransaction
    {
        IDbContextTransaction GetTransaction();
    }

    class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly AppDbContext _context;

        public DatabaseTransaction(AppDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
