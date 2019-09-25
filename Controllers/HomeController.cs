using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Data;
using ProjectX.Models;
using ProjectX.Models.Logic.MainBoard;
using ProjectX.ViewModels;

namespace ProjectX.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenerateWorkersList _generateWorkersData;
        private readonly IWorkerBoardUpdate _workerBoardUpdate;
        private readonly WorkersContext _context;

        public HomeController(
            IGenerateWorkersList generateWorkersList,
            IWorkerBoardUpdate workerBoardUpdate,
            WorkersContext context
            )
        {
            _generateWorkersData = generateWorkersList;
            _workerBoardUpdate = workerBoardUpdate;
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = _generateWorkersData.GenerateWorkersData(_context);

            return PartialView(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateWorker(int dayId, int workerId, int shift, int unity, int resevr)
        {
            // SET THAT DAY ID TO DATE 
            _workerBoardUpdate.UpdateWorkersBoard(_context, dayId, workerId, shift, unity, resevr);
            return Content("Yes");
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
