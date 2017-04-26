using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCompanyName.AbpProjectName.Web.Startup;

namespace AbpCompanyName.AbpProjectName.Web.Tests
{
    [DependsOn(
        typeof(AbpProjectNameWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class AbpProjectNameWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpProjectNameWebTestModule).GetAssembly());
        }
    }
}