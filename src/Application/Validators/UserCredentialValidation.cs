using Application.DTOs.EntityDTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UserCredentialValidation : AbstractValidator<UserCredentialDTO>
    {
        public UserCredentialValidation()
        {

        }
    }
}
