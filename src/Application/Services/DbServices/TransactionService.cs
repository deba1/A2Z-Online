using Application.Interfaces.DBContextInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Services.DbServices
{
    public interface ITransactionService
    {
        IDbContextTransaction GetTransaction();
    }

    class TransactionService : ITransactionService
    {
        private readonly DbContext _context;
        public TransactionService(IAppDbContext context)
        {
            _context = context.Instance;
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
