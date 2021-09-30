using Application.DTOs.AuthenticationDTOs;
using FluentValidation;

namespace Application.Validators.AuthenticationDTOValidator
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(t => t.OldPassword)
                .Required()
                .StringRange(5, 50);

            RuleFor(t => t.NewPassword)
                .Required()
                .StringRange(5, 50);

            RuleFor(t => t.RepeatPassword)
                .Equal(t => t.NewPassword)
                .WithMessage("Password and repeat does not match");
        }
    }
}
