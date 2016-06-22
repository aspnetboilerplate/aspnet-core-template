using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.AspNetCore.TestBase;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Tests.TestDatas;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shouldly;

namespace AbpCompanyName.AbpProjectName.Web.Tests
{
    public abstract class AbpProjectNameWebTestBase : AbpAspNetCoreIntegratedTestBase<Startup>
    {
        protected AbpProjectNameWebTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual async Task<T> GetResponseAsObjectAsync<T>(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var strResponse = await GetResponseAsStringAsync(url, expectedStatusCode);
            return JsonConvert.DeserializeObject<T>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        protected virtual async Task<string> GetResponseAsStringAsync(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await GetResponseAsync(url, expectedStatusCode);
            return await response.Content.ReadAsStringAsync();
        }

        protected virtual async Task<HttpResponseMessage> GetResponseAsync(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await Client.GetAsync(url);
            response.StatusCode.ShouldBe(expectedStatusCode);
            return response;
        }

        protected virtual void UsingDbContext(Action<AbpProjectNameDbContext> action)
        {
            using (var context = IocManager.Resolve<AbpProjectNameDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<AbpProjectNameDbContext, T> func)
        {
            T result;

            using (var context = IocManager.Resolve<AbpProjectNameDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<AbpProjectNameDbContext, Task> action)
        {
            using (var context = IocManager.Resolve<AbpProjectNameDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<AbpProjectNameDbContext, Task<T>> func)
        {
            T result;

            using (var context = IocManager.Resolve<AbpProjectNameDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}