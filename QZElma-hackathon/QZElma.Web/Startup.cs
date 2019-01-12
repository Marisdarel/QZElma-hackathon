using Autofac;
using Autofac.Extensions.DependencyInjection;
using ChatBotService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QZElma.Server.ConfigurationOptions;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.Database.DBContexts;
using QZElma.Web.AutoMapper;
using System;


namespace QZElma.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<EventBrokerOptions>(Configuration.GetSection(nameof(EventBrokerOptions)));

            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("QZElma.Web")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //ConfigureService
            services.Scan(x => x.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(classes => classes.WithAttribute<RepositoryService>())
                   .AsImplementedInterfaces()
                   .WithTransientLifetime()
                .AddClasses(classes => classes.WithAttribute<HelperService>())
                   .AsImplementedInterfaces()
                   .WithTransientLifetime()
                .AddClasses(classes => classes.WithAttribute<SelfHelperService>())
                   .AsSelf()
                   .WithTransientLifetime()
                .AddClasses(classes => classes.WithAttribute<ChatBotServiceAtt>())
                   .AsSelf()
                   .WithTransientLifetime()
            );

            services.AddHostedService<ChatBotListener>();

            services.AddSingleton<ChatBot>();

            services.AddCap(x =>
            {
                var eventBrokerOptions = new EventBrokerOptions();
                Configuration.GetSection(nameof(EventBrokerOptions)).Bind(eventBrokerOptions);

                x.UsePostgreSql(eventBrokerOptions.DBConnection);
                x.UseRabbitMQ(eventBrokerOptions.RabbitMQHost);
                x.Version = "v1.0";
            });

            services.AddLogging(configure => configure
                .AddConsole()
                .AddDebug());

            var builder = new ContainerBuilder();
            builder.Populate(services);
            ApplicationContainer = builder.Build();

            AutoMapperProfile.Initialize();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
