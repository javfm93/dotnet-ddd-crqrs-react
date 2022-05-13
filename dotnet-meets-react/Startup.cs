using dotnet_meets_react.Extensions;
using dotnet_meets_react.src.contexts.activityTracker.activity.application;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnet_meets_react
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
            services
                .AddControllersWithViews()
                .AddFluentValidation(
                    config =>
                    {
                        config.RegisterValidatorsFromAssemblyContaining<DeleteActivityCommandHandler>();
                    }
                );

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(
                configuration =>
                {
                    configuration.RootPath = "src/apps/activityTracker/frontend/build";
                }
            );

            services.AddDbContext<Repositories>(
                opt =>
                {
                    opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                }
            );

            services.AddMediatR(typeof(GetActivitiesQueryHandler).Assembly);
            services.AddTransient<ActivityRepository>();
            services.AddTransient<UpdateActivity>();
            services.AddTransient<GetActivities>();
            services.AddTransient<GetActivity>();
            services.AddTransient<DeleteActivity>();
            services.AddIdentityServices(Configuration);
            // services.Scan(scan => scan.AddType<IRepository>().AsSelf().WithTransientLifetime());
            // services.Scan(
            //     scan =>
            //         scan.FromAssemblyOf<IRepository>().AddClasses().AsSelf().WithTransientLifetime()
            // );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action=Index}/{id?}"
                    );
                }
            );

            app.UseSpa(
                spa =>
                {
                    spa.Options.SourcePath = "src/apps/activityTracker/frontend";

                    if (env.IsDevelopment())
                    {
                        spa.UseReactDevelopmentServer(npmScript: "start");
                    }
                }
            );
        }
    }
}
