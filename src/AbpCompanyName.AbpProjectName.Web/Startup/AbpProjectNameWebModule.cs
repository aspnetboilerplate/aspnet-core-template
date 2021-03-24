using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCompanyName.AbpProjectName.Configuration;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace AbpCompanyName.AbpProjectName.Web.Startup
{
    [DependsOn(
        typeof(AbpProjectNameApplicationModule), 
        typeof(AbpProjectNameEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpProjectNameWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpProjectNameWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(AbpProjectNameConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<AbpProjectNameNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpProjectNameApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpProjectNameWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AbpProjectNameWebModule).Assembly);
        }
    }
}
