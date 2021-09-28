using Application.DTOs.EntityDTOs;
using Application.Repositories;
using FluentValidation;

namespace Application.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbackDTO>
    {
        public FeedbackValidator(IProductRepository productRepository)
        {
            RuleFor(t => t.ProductId)
                .Required()
                .MustAsync(async (t, _) => (await productRepository.GetById(t)) != null)
                .WithMessage("Product doesn't exit.");

            RuleFor(t => t.Score)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5)
                .WithMessage("{PropertyName} must be between 1 and 5");
        }
    }
}
