using System.Reflection;
using Abp.Modules;
using Abp.TestBase;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AbpCompanyName.AbpProjectName.Tests
{
    [DependsOn(
        typeof(AbpProjectNameApplicationModule),
        typeof(AbpProjectNameEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule)
        )]
    public class AbpProjectNameTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                IocManager.IocContainer,
                services
            );

            var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
            builder.UseInMemoryDatabase()
                .UseInternalServiceProvider(serviceProvider);

            var options = builder.Options;

            IocManager.IocContainer.Register(
                Component.For<DbContextOptions<AbpProjectNameDbContext>>().Instance(options).LifestyleSingleton()
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}