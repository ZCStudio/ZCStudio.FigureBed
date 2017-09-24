using Microsoft.AspNetCore.Mvc;

namespace ZCStudio.FigureBed.Controllers
{
    public class FigureController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Search");
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}