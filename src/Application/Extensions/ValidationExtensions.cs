using Application.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
