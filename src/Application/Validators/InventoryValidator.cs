using Application.DTOs.EntityDTOs;
using Application.Repositories;
using FluentValidation;

namespace Application.Validators
{
    public class InventoryValidator : AbstractValidator<InventoryDTO>
    {
        public InventoryValidator(IProductRepository productRepository)
        {
            RuleFor(t => t.ProductId)
                .Required()
                .MustAsync(async (t, _) => (await productRepository.GetById(t)) != null)
                .WithMessage("Product doesn't exit.");

            RuleFor(t => t.Quantity)
                .Required();

            RuleFor(t => t.UnitPrice)
                .Required();
        }
    }
}
