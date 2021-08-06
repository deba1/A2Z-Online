using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IPaymentManager : IBaseManager<Payment>
    {

    }

    class PaymentManager : BaseManager<Payment>, IPaymentManager
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository, IMapper mapper) : base(paymentRepository, mapper)
        {
            _paymentRepository = paymentRepository;
        }
    }
}
