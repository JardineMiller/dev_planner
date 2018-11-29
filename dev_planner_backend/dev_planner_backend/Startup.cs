using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Configuration;
using dev_planner_backend.Contexts;
using dev_planner_backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;

namespace dev_planner_backend
{
    public class Startup
    {
        public static IConfiguration Config { get; private set; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configs
            services.Configure<DatabaseConfig>(Config.GetSection("database"));
            services.Configure<MailServiceConfig>(Config.GetSection("mailSettings"));

            // Database
            var serviceProvider = services.BuildServiceProvider();
            var connection = serviceProvider.GetService<IOptions<DatabaseConfig>>().Value.Connection;
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connection));
            services.AddScoped<ISeeder, DatabaseSeeder>();

            // Services
            services.AddMvc();
            services.AddTransient<IMailService, LocalMailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ISeeder seeder)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            
            seeder.SeedAll();

            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}