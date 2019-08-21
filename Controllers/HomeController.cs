using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Models;
using ProjectX.Models.Logic.MainBoard;
using ProjectX.ViewModels;

namespace ProjectX.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenerateWorkersList _generateWorkersList;

        public HomeController(
            IGenerateWorkersList generateWorkersList
            )
        {
            _generateWorkersList = generateWorkersList;
        }
        public IActionResult Index()
        {
            var data = _generateWorkersList.GenerateWorkersList();

            return PartialView(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
