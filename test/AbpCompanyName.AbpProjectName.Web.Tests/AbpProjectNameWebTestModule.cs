using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;

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
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}