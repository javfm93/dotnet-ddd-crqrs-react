using dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_meets_react.Extensions
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddIdentityCore<User>().AddEntityFrameworkStores<Repositories>().AddSignInManager<SignInManager<User>>();
            services.AddAuthentication();

            return services;
        }
    }
}