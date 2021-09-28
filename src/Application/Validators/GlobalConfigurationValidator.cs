using Application.DTOs.EntityDTOs;
using FluentValidation;

namespace Application.Validators
{
    public class GlobalConfigurationValidator : AbstractValidator<GlobalConfigurationDTO>
    {
        public GlobalConfigurationValidator()
        {
            RuleFor(t => t.KeyId)
                .Required();
        }
    }
}
