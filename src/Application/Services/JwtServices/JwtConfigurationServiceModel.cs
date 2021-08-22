using Microsoft.Extensions.Configuration;
using System;

namespace Application.Services.JwtServices
{
    class JwtConfigurationServiceModel
    {
        private readonly IConfiguration _config;

        public JwtConfigurationServiceModel(IConfiguration config)
        {
            _config = config;
        }

        protected IConfigurationSection JwtSection
        {
            get => _config.GetSection("JWT");
        }

        protected string Issuer
        {
            get => JwtSection.GetSection("Issuer").Value;
        }

        protected string Audience
        {
            get => JwtSection.GetSection("Audience").Value;
        }

        protected string Key
        {
            get => JwtSection.GetSection("Key").Value;
        }

        protected string RefreshKey
        {
            get => JwtSection.GetSection("RefreshKey").Value;
        }

        protected int ValidationTime
        {
            get => Convert.ToInt32(JwtSection.GetSection("ValidationTime").Value);
        }
    }
}
