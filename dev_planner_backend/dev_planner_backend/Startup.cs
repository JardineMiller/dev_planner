﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            var connectionString = Startup.Config["connectionStrings:DBConnectionString"];

            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
            services.AddTransient<IMailService, LocalMailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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

            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}