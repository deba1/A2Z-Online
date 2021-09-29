using Application.DTOs.AuthenticationDTOs;
using FluentValidation;

namespace Application.Validators.AuthenticationDTOValidator
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(t => t.OldPassword)
                .Required();

            RuleFor(t => t.NewPassword)
                .Required();

            RuleFor(t => t.RepeatPassword)
                .Equal(t => t.OldPassword)
                .WithMessage("Password and repeat does not match");
        }
    }
}
