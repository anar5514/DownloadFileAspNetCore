using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HowToDownloadFile.Models;
using System.IO;

namespace HowToDownloadFile.Controllers
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


        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var filePath = @"C:\Users\anara\OneDrive\Desktop\test\test.txt";

            var memory = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(memory);

                memory.Position = 0;

                return File(memory, "text/plain", Path.GetFileName(filePath));
            }
        }


    }
}
