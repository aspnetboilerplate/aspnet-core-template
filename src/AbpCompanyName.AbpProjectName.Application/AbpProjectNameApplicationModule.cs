using System.Reflection;
using Abp.Modules;

namespace AbpCompanyName.AbpProjectName
{
    [DependsOn(typeof(AbpProjectNameCoreModule))]
    public class AbpProjectNameApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}