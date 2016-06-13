using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;

namespace AbpCompanyName.AbpProjectName.Web.Services
{
    public class MyService : ITransientDependency
    {
        public int GetValue()
        {
            return 42;
        }
    }
}
