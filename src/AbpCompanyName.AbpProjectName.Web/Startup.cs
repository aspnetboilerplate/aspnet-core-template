using System;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Filters;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AbpCompanyName.AbpProjectName.Web
{
    public class Startup : AbpStartup
    {
        public Startup(IHostingEnvironment env, bool initialize = true)
            : base(env, initialize)
        {
             
        }

        protected override void InitializeAbp()
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseLog4Net().WithConfig("log4net.config")
                );

            base.InitializeAbp();
        }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //See https://github.com/aspnet/Mvc/issues/3936 to know why we added these services.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AbpAuthorizationFilter));
                options.Filters.Add(typeof(AbpExeptionFilter));
                options.Filters.Add(typeof(AbpResultFilter));

                //TODO: InputFotmatter!

                options.OutputFormatters.Add(new JsonOutputFormatter(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }));

            }).AddControllersAsServices();


            return base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            base.Configure(app, env, loggerFactory);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
