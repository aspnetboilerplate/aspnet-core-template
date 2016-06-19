using System;
using System.Threading.Tasks;
using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Tests.TestDatas;

namespace AbpCompanyName.AbpProjectName.Tests
{
    public class AbpProjectNameTestBase : AbpIntegratedTestBase
    {
        public AbpProjectNameTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);
            modules.Add<AbpProjectNameTestModule>();
        }

        public void UsingDbContext(Action<AbpProjectNameDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<AbpProjectNameDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<AbpProjectNameDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpProjectNameDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        public async Task UsingDbContextAsync(Func<AbpProjectNameDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<AbpProjectNameDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        public async Task<T> UsingDbContextAsync<T>(Func<AbpProjectNameDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpProjectNameDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
