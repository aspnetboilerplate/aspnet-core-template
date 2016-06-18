using System.Reflection;
using Abp.AspNetCore;
using Abp.Modules;

namespace AbpCompanyName.AbpProjectName.Web
{
    [DependsOn(typeof(AbpProjectNameCoreModule), typeof(AbpAspNetCoreModule))]
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