using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCompanyName.AbpProjectName.Localization;

namespace AbpCompanyName.AbpProjectName
{
    public class AbpProjectNameCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            AbpProjectNameLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AbpProjectNameConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpProjectNameCoreModule).GetAssembly());
        }
    }
}