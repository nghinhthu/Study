using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MSA.FW.Validation;
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
        private readonly IOTPServiceHandler otpServiceHandler;

        public HomeController(ILogger<HomeController> logger,
            IOptions<ApplicationConfiguration> appConfig,
            IOTPServiceHandler _otpServiceHandler)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            otpServiceHandler = _otpServiceHandler;
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
        [HttpPost]
        public async Task<IActionResult> RequestOTP(OTPRequestModel model)
        {
            model.SessionID = "123";
            model.RequesterID = "thu";
            model.TCodeKey = "89021f49-2c3a-47df-bbad-74680019b123";
            model.RequestDateTime = DateTime.Today;
            RequestOTP requestOTP = new RequestOTP(model);
            BOProcessResult result = await otpServiceHandler.GetOTPCode(requestOTP);
            return Ok(result);
        }

        public IActionResult RequestOTP()
        {
            ViewBag.AppConfig = _appConfig.ConnectionString;
            return View();
        }
    }
}
