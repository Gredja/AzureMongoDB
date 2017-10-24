using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureMongoDB.Models;
using AzureMongoDB.Services.Interfaces;

namespace AzureMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDebtorDbRepository _repository;


        public HomeController(IDebtorDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var debtors = await _repository.GetAllDebtors();

            return View(debtors);
        }

        public async Task<IActionResult> AddDebtor()
        {
            await _repository.AddOneDebtor(new Debtor
            {
                Id = Guid.NewGuid().ToString(),
                Name = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });

            return RedirectToAction("Index");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
