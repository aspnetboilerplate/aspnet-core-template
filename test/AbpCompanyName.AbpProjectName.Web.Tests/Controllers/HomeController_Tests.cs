using System.Net;
using System.Threading.Tasks;
using Abp.Web.Mvc.Models;
using AbpCompanyName.AbpProjectName.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpCompanyName.AbpProjectName.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpProjectNameWebTestBase
    {
        [Fact]
        public async Task Index_Should_Return_Products_List_View()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                               GetUrl<HomeController>(nameof(HomeController.Index))
                           );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetUserFriendlyException_Should_Be_Handled_And_Return_Provided_Message()
        {
            //Act
            var response = await GetResponseAsObjectAsync<MvcAjaxResponse>(
                               GetUrl<HomeController>(nameof(HomeController.GetUserFriendlyException)),
                               HttpStatusCode.InternalServerError
                           );

            response.Success.ShouldBeFalse();
            response.Error.ShouldNotBe(null);
            response.Error.Message.ShouldBe("Test User Friendly Exception");
        }
    }
}
