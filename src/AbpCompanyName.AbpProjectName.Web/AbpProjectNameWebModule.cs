using System.Reflection;
using Abp.AspNetCore;
using Abp.Modules;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.Web
{
    [DependsOn(
        typeof(AbpProjectNameApplicationModule), 
        typeof(AbpProjectNameEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpProjectNameWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}