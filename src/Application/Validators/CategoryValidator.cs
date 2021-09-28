using Application.DTOs.EntityDTOs;
using FluentValidation;

namespace Application.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(t => t.Title)
                .Required();

            RuleFor(t => t.Thumbnail)
                .Required();
        }
    }
}
