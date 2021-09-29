using Application.DTOs.EntityDTOs;
using FluentValidation;

namespace Application.Validators.EntityDTOValidator
{
    public class UserCredentialValidation : AbstractValidator<UserCredentialDTO>
    {
        public UserCredentialValidation()
        {

        }
    }
}
