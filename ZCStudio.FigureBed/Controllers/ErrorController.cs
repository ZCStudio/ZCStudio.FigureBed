using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZCStudio.FigureBed.Models;

namespace ZCStudio.FigureBed.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("[controller]/[action]/{statusCode=404}")]
        public IActionResult Code(string statusCode)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, StatusCode = statusCode });
        }
    }
}