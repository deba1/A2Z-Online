using Application.DTOs.EntityDTOs;
using Application.Repositories;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator(IProductRepository productRepository)
        {
            RuleFor(t => t.ShippingAddress)
                .Required();

            RuleFor(t => t.Phone)
                .ValidMobileNo();

            RuleFor(t => t.DeliveryCharge)
                .Must(t => t >= 0)
                .WithMessage("Delivery charge can't be negative");

            When(t => t.ReturnedOn.HasValue, () =>
            {
                RuleFor(t => t.DeliveredOn)
                    .Must(t => t.HasValue)
                    .WithMessage("Order has not been delivered yet.");
            });

            RuleFor(t => t.OrderItems)
                .NotEmpty()
                .WithMessage("At least 1 item is required.");

            RuleForEach(t => t.OrderItems)
                .ChildRules(orderItemRule =>
                {
                    orderItemRule.RuleFor(t => t.ProductId)
                        .Required()
                        .MustAsync(async (productId, _) => (await productRepository.GetById(productId)) != null)
                        .WithMessage("Product Doesn't exist.");

                    orderItemRule.RuleFor(t => t.Quantity)
                        .Required()
                        .GreaterThan(0)
                        .WithMessage("Quantity is required.");
                });
        }
    }
}
