using System.Threading.Tasks;
using AbpCompanyName.AbpProjectName.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpCompanyName.AbpProjectName.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpProjectNameWebTestBase
    {
        [Fact]
        public async Task Test1()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                               GetUrl<HomeController>(nameof(HomeController.Index))
                           );

            //Assert

            response.ShouldNotBeNullOrEmpty();
        }
    }
}
