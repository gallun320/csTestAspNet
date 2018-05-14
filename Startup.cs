﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CsTesAspNet.Models;

namespace CsTestAspNet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuation { get; }
        public Startup(IConfiguration configuration)
        {
            Configuation = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuation.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddDbContext<ProductContext>(options => options.UseSqlite(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => {
                routes.MapRoute(name: "default", 
                                template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
