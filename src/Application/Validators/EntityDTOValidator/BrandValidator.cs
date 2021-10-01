using Application.DTOs.EntityDTOs;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class BrandValidator : AbstractValidator<BrandDTO>
    {
        public BrandValidator()
        {
            RuleFor(t => t.Name)
                .Required();
        }
    }
}
