using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OTPService.Logic;
using OTPService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationConfiguration _appConfig;
        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationConfiguration> appConfig)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
        }

        public IActionResult Index()
        {
            ViewBag.AppConfig = _appConfig.ConnectionString;
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

        public async Task<IActionResult> RequestOTP(OTPRequestModel model)
        {
            RequestOTP requestOTP = new RequestOTP(model);
            BOProcessResult result = await
            return RedirectToAction("Index");


        }
    }
}
