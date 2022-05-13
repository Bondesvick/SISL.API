using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SISL.API.Constants;
using SISL.API.Filters;
using SISL.Core.Entities;
using SISL.Core.Helpers;
using SISL.Core.Interfaces;
using SISL.Core.Services;
using SISL.Infrastructure;
using SISL.Infrastructure.Configurations;
using SISL.Infrastructure.Data;
using SISL.Infrastructure.Repository;

namespace SISL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SISL.Core.Models.AppSettings.ConnectToLocalRedis = Convert.ToBoolean(Configuration["AppSettings:ConnectToLocalRedis"]);
            SISL.Core.Models.AppSettings.SetRedisApi = Configuration["AppSettings:SetRedisApi"];
            SISL.Core.Models.AppSettings.GetRedisApi = Configuration["AppSettings:GetRedisApi"];
            SISL.Core.Models.AppSettings.ValidateToken = Configuration["AppSettings:ValidateToken"];

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services
                .AddDbContext<AppDbContext>(optionsAction: (optionsBuilder) =>
                    optionsBuilder.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader());
            //});

            //services.AddCors(options => options.ConfigureCorsPolicy(Configuration));

            var allowedOriginsConfig = Configuration["AppSettings:AllowedOrigins"];
            var allowedOrigins = string.IsNullOrEmpty(allowedOriginsConfig) ? new string[] { } : allowedOriginsConfig.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(o => o.Trim());

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(allowedOrigins.ToArray());
                });
            });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddScoped<ModelStateValidationFilter>();

            //DinkDof HTML to pdf converter
            //services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddServiceCollections();

            //services.AddHttpClient<IIdValidationService, IdValidationService>(c =>
            //{
            //    //c.BaseAddress = new Uri(Configuration["AppSettings:IdValidationServiceBaseEndPoint"]);
            //    c.BaseAddress = new Uri(Configuration["AppSettings:IdBaseEndPoint"]);
            //});

            services.AddControllers();
            //services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SISL.API",
                    Version = "v1",
                    Description = "API SISL Account Management"
                });
            });

            var ignoreCertHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            services.AddHttpClient("AuthClient", client => { })
                .ConfigurePrimaryHttpMessageHandler(() => ignoreCertHandler);

            services.AddMemoryCache();

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = Configuration.GetConnectionString("RedisConnection"));

            //services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            //var jwtTokenConfig = Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();
            //services.AddSingleton(jwtTokenConfig);
            //services.AddAuthentication((x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

            //services.AddAuthentication()
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/Account/Unauthorized/";
            //        options.AccessDeniedPath = "/Account/Forbidden/";
            //    })
            //    .AddJwtBearer(options =>
            //    {
            //        options.Audience = "http://localhost:5001/";
            //        options.Authority = "http://localhost:5000/";
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SISL.API v1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            //app.UseCors("AllowSpecifiedHostsOnly");

            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}