using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SISL.Core.Entities;
using SISL.Core.Interfaces;
using SISL.Core.Services;
using SISL.Infrastructure.Repository;

namespace SISL.API.Constants
{
    public static class ServiceCollections
    {
        public static void AddServiceCollections(this IServiceCollection service)
        {
            service.AddScoped<IRepository<CustomerAccount>, EfRepository<CustomerAccount>>();
            service.AddScoped<IRepository<SislHistory>, EfRepository<SislHistory>>();
            service.AddScoped<IRepository<SislStatus>, EfRepository<SislStatus>>();

            service.AddScoped<ICustomerAccountService, CustomerAccountService>();
            service.AddScoped<ISislHistoryRepository, SislHistoryRepository>();

            service.AddScoped<IIdValidationService, IdValidationService>();
            service.AddScoped<ISmileHelper, SmileHelper>();
            service.AddScoped<IHttpRequest, HttpRequest>();

            service.AddScoped<IAppLogger, AppLoger>();
            service.AddScoped<IAppSettings, AppSettings>();
            service.AddScoped<ISoapRequestHelper, SoapRequestHelper>();
            service.AddScoped<IRedboxEmailService, RedboxEmailServiceProxy>();

            service.AddScoped<IAuthenticateService, AuthenticateService>();
            service.AddScoped<IJsonRequestHelper, JsonRequestHelper>();

            service.AddScoped<IRedboxRequestManagerProxy, RedboxRequestManagerProxy>();
            service.AddScoped<IRedboxAccountServiceProxy, AccountServiceProxy>();

            service.AddScoped<ICallInfoWare, CallInfoWare>();
            service.AddScoped<IRedboxNipService, RedboxNipService>();
        }

        public static CorsOptions ConfigureCorsPolicy(this CorsOptions corsOptions, IConfiguration configuration)
        {
            var allowedOriginsConfig = configuration["AppSettings:AllowedOrigins"];
            var allowedOrigins = string.IsNullOrEmpty(allowedOriginsConfig) ? new string[] { } : allowedOriginsConfig.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(o => o.Trim());
            if (allowedOrigins.Any())
            {
                corsOptions.AddPolicy("AllowSpecifiedHostsOnly",
                    corsPolicyBuilder => corsPolicyBuilder
                        .WithOrigins(allowedOrigins.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            }
            else
            {
                corsOptions.AddPolicy("AllowSpecifiedHostsOnly",
                    corsPolicyBuilder => corsPolicyBuilder
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            }
            return corsOptions;
        }
    }
}