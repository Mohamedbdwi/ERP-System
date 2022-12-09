using Microsoft.AspNetCore.Mvc;

namespace Small_ERP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
