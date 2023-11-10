using Blog.Web.Areas.Admin.Models;
using Blog.Web.Controllers;
using Blog.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

