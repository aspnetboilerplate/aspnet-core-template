using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.Web.Startup
{
    [DependsOn(
        typeof(AbpProjectNameApplicationModule), 
        typeof(AbpProjectNameEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpProjectNameWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AbpProjectNameNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpProjectNameApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}