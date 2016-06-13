using Abp.AspNetCore.Mvc.Controllers;
using AbpCompanyName.AbpProjectName.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    public class HomeController : AbpController
    {
        private readonly MyService _myService;

        public HomeController(MyService myService)
        {
            _myService = myService;
        }

        public IActionResult Index()
        {
            ViewBag.Number = _myService.GetValue();
            return View();
        }
    }
}