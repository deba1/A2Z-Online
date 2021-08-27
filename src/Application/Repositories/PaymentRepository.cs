using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {

    }

    class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly IAppDbContext _context;

        public PaymentRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
