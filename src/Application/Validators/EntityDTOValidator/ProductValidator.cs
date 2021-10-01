using Application.DTOs.EntityDTOs;
using Application.Repositories;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator(
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository
            )
        {
            RuleFor(t => t.Name)
                .Required();

            RuleFor(t => t.Description)
                .Required();

            RuleFor(t => t.Price)
                .Required();

            RuleFor(t => t.Thumbnail)
                .Required();

            RuleFor(t => t.BrandId)
                .Required()
                .MustAsync(async (t, _) => (await brandRepository.GetById(t)) != null)
                .WithMessage("Brand doesn't exist.");

            RuleFor(t => t.CategoryId)
                .Required()
                .MustAsync(async (t, _) => (await categoryRepository.GetById(t)) != null)
                .WithMessage("Category doesn't exist.");

            When(t => !string.IsNullOrEmpty(t.Images), () =>
            {
                RuleFor(t => t.Images)
                    .ValidJson();
            });

            When(t => !string.IsNullOrEmpty(t.AdditionalFields), () =>
            {
                RuleFor(t => t.AdditionalFields)
                    .ValidJson();
            });
        }
    }
}
