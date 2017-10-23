using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly IMongoDbRepository _repository;


        public HomeController(IMongoDbRepository repository)
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
            var debtors = await _repository.GetAllDebtors();
            var id = Convert.ToInt32(debtors.Max(x => x.Id)) + 1;

            await _repository.AddDebtor(new Debtor() { Id = id.ToString(), Name = DateTime.Now.ToString(CultureInfo.InvariantCulture) });

            return RedirectToAction("Index");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
