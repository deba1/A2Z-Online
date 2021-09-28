using Application.DTOs.AuthenticationDTOs;
using FluentValidation;

namespace Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(t => t.Email)
                .Required()
                .EmailAddress()
                .WithMessage("Invalid Email");

            RuleFor(t => t.Password)
                .Required()
                .StringRange(5, 50);
        }
    }
}
