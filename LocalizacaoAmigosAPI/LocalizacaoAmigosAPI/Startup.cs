namespace LocalizacaoAmigosAPI
{
    using LocalizacaoAmigos.CrossCuting.Authentication;
    using LocalizacaoAmigos.CrossCuting.Authentication.Interfaces;
    using LocalizacaoAmigos.Domain.Auxiliar;
    using LocalizacaoAmigos.Domain.Interfaces;
    using LocalizacaoAmigos.Service.Services;
    using LocalizacaoAmigosService.Services;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.Owin.Security.OAuth;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFriendsService, FriendsService>();
            services.AddTransient<ICalculoHistoricoLogService, CalculoHistoricoLogService>();
            services.AddTransient<IUserService, UserServices>();
            services.AddTransient<ITokenHandler, TokenHandler>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var signingConfigurations = new SigninConfigurations();
            services.AddSingleton(signingConfigurations);

            IdentityModelEventSource.ShowPII = true;

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(jwtBearerOptions =>
               {
                   jwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = tokenOptions.Issuer,
                       ValidAudience = tokenOptions.Audience,
                       IssuerSigningKey = signingConfigurations.Key,
                       ClockSkew = TimeSpan.Zero
                   };
               });
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();




        }

    }
}