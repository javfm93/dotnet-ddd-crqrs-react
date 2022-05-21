using System.Text;
using dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure;
using dotnet_meets_react.src.contexts.activityTracker.user.application;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_meets_react.Extensions
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                .AddIdentityCore<User>()
                .AddEntityFrameworkStores<Repositories>()
                .AddSignInManager<SignInManager<User>>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    opt =>
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false
                        }
                );
            services.AddScoped<TokenService>();

            return services;
        }
    }
}
