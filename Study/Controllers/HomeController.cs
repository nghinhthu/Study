using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int currentLayout = 1;

            List<SelectListModel> layoutList = new List<SelectListModel>();
            layoutList.Add(new SelectListModel("1", "Layout 1"));
            layoutList.Add(new SelectListModel("2", "Layout 2"));
            layoutList.Add(new SelectListModel("3", "Layout 3"));
            SelectList selectLayoutList = new SelectList(layoutList, "Key", "Value");
            ViewBag.LayoutList = selectLayoutList;

            List<SelectListModel> fontList = new List<SelectListModel>();
            fontList.Add(new SelectListModel("1", "Times New Roman"));
            fontList.Add(new SelectListModel("2", "Dongle"));
            fontList.Add(new SelectListModel("3", "Poppins"));
            fontList.Add(new SelectListModel("4", "Mochiy Pop P One"));
            SelectList selectFontList = new SelectList(fontList, "Key", "Value");
            ViewBag.FontList = selectFontList;


            List<SelectListModel> colorList = new List<SelectListModel>();
            colorList.Add(new SelectListModel("1", "Black"));
            colorList.Add(new SelectListModel("2", "Red"));
            colorList.Add(new SelectListModel("3", "Yellow"));
            colorList.Add(new SelectListModel("4", "Light Coral"));
            SelectList selectColorList = new SelectList(colorList, "Key", "Value");
            ViewBag.ColorList = selectColorList;
            string layoutName;
            int id = Convert.ToInt32(TempData["LayoutID"]);
            if (id == 0)
            {
                layoutName = "Index" + currentLayout;
            }
            else
            {
                layoutName = "Index" + id;
            }
            return View(layoutName);
        }

        public ActionResult SelectLayout(int id)
        {
            TempData["LayoutID"] = id;
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult check(string button)
        {
            if (!string.IsNullOrEmpty(button))
            {
                TempData["ButtonValue"] = string.Format("{0} button clicked.", button);
            }
            else
            {
                TempData["ButtonValue"] = "No button click!";
            }
            return RedirectToAction("Index");
        }
    }
}
