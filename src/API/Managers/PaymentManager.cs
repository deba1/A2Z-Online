using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IPaymentManager : IBaseManager<Payment>
    {

    }

    class PaymentManager : BaseManager<Payment>, IPaymentManager
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository) : base(paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
    }
}
