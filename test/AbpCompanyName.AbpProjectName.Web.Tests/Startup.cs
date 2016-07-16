﻿using System;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Web.Controllers;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbpCompanyName.AbpProjectName.Web.Tests
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();

            var mvc = services.AddMvc(options =>
            {
                options.AddAbp(services); //Add ABP infrastructure to MVC
            });

            //Workaround defined here: https://github.com/aspnet/Mvc/issues/4897#issuecomment-228093609
            var parts = mvc.PartManager.ApplicationParts;
            parts.Clear();
            parts.Add(new AssemblyPart(typeof(HomeController).Assembly));

            mvc.AddControllersAsServices();

            //Configure Abp and Dependency Injection
            return services.AddAbp<AbpProjectNameWebTestModule>(options =>
            {
                options.SetupTest();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            UseInMemoryDb(app.ApplicationServices);

            app.UseAbp(); //Initializes ABP framework.

            app.UseExceptionHandler("/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

        private void UseInMemoryDb(IServiceProvider serviceProvider)
        {
            var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
            builder.UseInMemoryDatabase().UseInternalServiceProvider(serviceProvider);
            var options = builder.Options;

            var iocManager = serviceProvider.GetRequiredService<IIocManager>();

            iocManager.IocContainer
                .Register(
                    Component.For<DbContextOptions<AbpProjectNameDbContext>>()
                    .Instance(options)
                    .LifestyleSingleton()
                );
        }
    }
}
