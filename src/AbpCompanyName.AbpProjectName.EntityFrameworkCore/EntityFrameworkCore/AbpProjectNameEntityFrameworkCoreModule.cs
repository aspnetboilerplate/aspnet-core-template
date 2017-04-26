using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpProjectNameCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class AbpProjectNameEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpProjectNameEntityFrameworkCoreModule).GetAssembly());
        }
    }
}