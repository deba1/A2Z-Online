using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IPaymentRepository :IBaseRepository<Payment>
    {

    }

    class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
