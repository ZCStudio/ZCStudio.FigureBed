using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZCStudio.FigureBed.Models;
using System.Diagnostics;

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