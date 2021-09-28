using Application.DTOs.AuthenticationDTOs;
using FluentValidation;

namespace Application.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequestDTO>
    {
        public RefreshTokenValidator()
        {
            RuleFor(t => t.RefreshToken)
                .Required();
        }
    }
}
