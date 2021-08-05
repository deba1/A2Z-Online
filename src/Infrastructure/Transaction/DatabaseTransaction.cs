using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Transaction
{
    public interface IDatabaseTransaction
    {
        IDbContextTransaction Transaction { get; }
    }

    class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly AppDbContext _context;

        public DatabaseTransaction(AppDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction Transaction
        {
            get => _context.Database.BeginTransaction();
        }
    }
}
