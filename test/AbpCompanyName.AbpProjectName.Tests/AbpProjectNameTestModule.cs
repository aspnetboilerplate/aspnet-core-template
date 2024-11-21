using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AbpCompanyName.AbpProjectName.Tests;

[DependsOn(
    typeof(AbpProjectNameApplicationModule),
    typeof(AbpProjectNameEntityFrameworkCoreModule),
    typeof(AbpTestBaseModule)
    )]
public class AbpProjectNameTestModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        SetupInMemoryDb();
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(AbpProjectNameTestModule).GetAssembly());
    }

    private void SetupInMemoryDb()
    {
        var services = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase();

        var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
            IocManager.IocContainer,
            services
        );

        var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
        builder.UseInMemoryDatabase("Test").UseInternalServiceProvider(serviceProvider);

        IocManager.IocContainer.Register(
            Component
                .For<DbContextOptions<AbpProjectNameDbContext>>()
                .Instance(builder.Options)
                .LifestyleSingleton()
        );
    }
}