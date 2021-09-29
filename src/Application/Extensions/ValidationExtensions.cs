using Application.Validators.AuthenticationDTOValidator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IMvcBuilder AddFluentValidations(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
            });
            return builder;
        }
    }
}
