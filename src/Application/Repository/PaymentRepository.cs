using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {

    }

    class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly DbContext _context;

        public PaymentRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
