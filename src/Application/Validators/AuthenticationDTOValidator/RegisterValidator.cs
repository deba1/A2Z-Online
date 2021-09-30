using Application.DTOs.AuthenticationDTOs;
using Application.Managers;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Validators.AuthenticationDTOValidator
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        private readonly IUserCredentialManager _credentialManager;

        public RegisterValidator(IUserCredentialManager credentialManager)
        {
            _credentialManager = credentialManager;

            RuleFor(t => t.Name)
                .Required();

            RuleFor(t => t.Email)
                .Required()
                .EmailAddress()
                .WithMessage("Invalid Email Address")
                .MustAsync(UniqueEmail)
                .WithMessage("Email already registered");

            RuleFor(t => t.Gender)
                .IsInEnum()
                .WithMessage("Invalid Gender.");

            RuleFor(t => t.DateOfBirth)
                .ValidAge()
                .WithMessage("Invalid Date of Birth");

            RuleFor(t => t.Password)
                .StringRange(5, 50);

            RuleFor(t => t.RepeatPassword)
                .Equal(t => t.Password)
                .WithMessage("Password and Repeat Password did't match");

            RuleFor(t => t.MobileNo)
                .ValidMobileNo();

            RuleFor(t => t.Address)
                .Required();
        }

        private async Task<bool> UniqueEmail(string email, CancellationToken cancellationToken)
        {
            var result = await _credentialManager.EmailExists(email);
            return !result;
        }
    }
}
