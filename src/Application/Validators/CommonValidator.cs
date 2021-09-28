using FluentValidation;
using Newtonsoft.Json;
using System;

namespace Application.Validators
{
    public static class CommonValidator
    {
        public static IRuleBuilderOptions<T, string> Required<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName} is required.");
        }
        public static IRuleBuilderOptions<T, string> ValidJson<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(t => {
                    try
                    {
                        JsonConvert.DeserializeObject(t);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage("Malformed {PropertyName}.");
        }

        public static IRuleBuilderOptions<T, int> Required<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName} is required.");
        }

        public static IRuleBuilderOptions<T, decimal> Required<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName} is required.");
        }

        public static IRuleBuilderOptions<T, DateTime> Required<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .Must(t => t > DateTime.MinValue)
                .WithMessage("{PropertyName} is required.");
        }

        public static IRuleBuilderOptions<T, DateTime> ValidAge<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThanOrEqualTo(DateTime.UtcNow.Subtract(TimeSpan.FromDays(365 * 150)))
                .LessThan(DateTime.UtcNow)
                .WithMessage("{PropertyName} is invalid.");
        }

        public static IRuleBuilderOptions<T, string> ValidMobileNo<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.StartsWith("+880"))
                .WithMessage("{PropertyName} must start with +880.");
        }

        public static IRuleBuilderOptions<T, string> StringRange<T>(this IRuleBuilder<T, string> ruleBuilder, int min, int max)
        {
            return ruleBuilder
                .MinimumLength(min)
                .WithMessage($"{{PropertyName}} must be at least {min} characters long.")
                .MaximumLength(max)
                .WithMessage($"{{PropertyName}} must be at most {max} characters long.");
        }
    }
}
