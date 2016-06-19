using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
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

        public async Task<IActionResult> Index()
        {
            var model = await _productAppService.GetAllProducts();
            return View(model);
        }
    }
}