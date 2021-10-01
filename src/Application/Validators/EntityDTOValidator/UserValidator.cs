using Application.DTOs.EntityDTOs;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(t => t.Name)
                .Required();

            RuleFor(t => t.Gender)
                .IsInEnum()
                .WithMessage("Invalid Gender");

            RuleFor(t => t.DateOfBirth)
                .ValidAge()
                .WithMessage("Date of Birth is invalid.");

            RuleFor(t => t.MobileNo)
                .ValidMobileNo();

            RuleFor(t => t.Address)
                .Required();
        }
    }
}
