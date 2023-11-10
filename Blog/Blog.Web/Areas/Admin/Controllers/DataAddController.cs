using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataAddController : Controller
    {
        public IActionResult Data()
        {
            return View();
        }
    }
}
