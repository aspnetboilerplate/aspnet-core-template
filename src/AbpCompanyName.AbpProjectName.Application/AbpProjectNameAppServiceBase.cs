using Abp.Application.Services;
using Abp.ObjectMapping;

namespace AbpCompanyName.AbpProjectName
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AbpProjectNameAppServiceBase : ApplicationService
    {
        /// <summary>
        /// Reference to the object to object mapper.
        /// TODO: REMOVE THIS WHEN IT'S ADDED TO ApplicationService in Abp.
        /// </summary>
        public IObjectMapper ObjectMapper { get; set; }
        
        protected AbpProjectNameAppServiceBase()
        {
            ObjectMapper = NullObjectMapper.Instance;
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
        }
    }
}