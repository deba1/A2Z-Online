﻿using Application.DTOs.EntityDTOs;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(t => t.Name)
                .Required();

            RuleFor(t => t.Gender)
                .Required()
                .IsEnumName(typeof(Gender))
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
