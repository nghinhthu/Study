﻿using Gigamall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Gigamall.Controllers
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
            return View();
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

        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult Promotion()
        {
            return View();
        }
        public IActionResult Event()
        {
            return View();
        }
        public IActionResult Brand()
        {
            return View();
        }
        public IActionResult Member()
        {
            return View();
        }
        public IActionResult Utilities()
        {
            return View();
        }
    }
}
