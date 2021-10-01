using Application.DTOs.EntityDTOs;
using Application.Repositories;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class PaymentValidator : AbstractValidator<PaymentDTO>
    {
        public PaymentValidator(IOrderRepository orderRepository)
        {
            RuleFor(t => t.OrderId)
                .Required()
                .MustAsync(async (t, _) => (await orderRepository.GetById(t)) != null)
                .WithMessage("Order doesn't exist.");

            RuleFor(t => t.Method)
                .Required();

            RuleFor(t => t.TotalAmount)
                .Required();

            RuleFor(t => t.Currency)
                .Required();

            RuleFor(t => t.Status)
                .Required();

            RuleFor(t => t.TransactionId)
                .Required();

            RuleFor(t => t.PaymentTime)
                .Required();
        }
    }
}
