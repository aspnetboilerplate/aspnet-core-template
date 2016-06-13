using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}