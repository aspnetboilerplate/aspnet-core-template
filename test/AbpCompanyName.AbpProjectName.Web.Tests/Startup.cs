﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AbpCompanyName.AbpProjectName.Web.Tests;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFrameworkInMemoryDatabase();

        services.AddMvc();

        //Configure Abp and Dependency Injection
        return services.AddAbp<AbpProjectNameWebTestModule>(options =>
        {
            options.SetupTest();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        UseInMemoryDb(app.ApplicationServices);

        app.UseAbp(); //Initializes ABP framework.

        app.UseExceptionHandler("/Error");

        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        });
    }

    private void UseInMemoryDb(IServiceProvider serviceProvider)
    {
        var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);
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
