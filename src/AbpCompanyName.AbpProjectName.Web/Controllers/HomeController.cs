using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.UI;
using AbpCompanyName.AbpProjectName.Products;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    public class HomeController : AbpController
    {
        private readonly IProductAppService _productAppService;

        public HomeController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _productAppService.GetAllProducts();
            return View(model);
        }

        public JsonResult GetUserFriendlyException()
        {
            throw new UserFriendlyException("Test User Friendly Exception", "This is a user friendly exception directly shown to the user.");
        }
    }
}