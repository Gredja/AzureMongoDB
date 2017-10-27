using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using AzureMongoDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureMongoDB.Controllers
{
    public class DebtorController : Controller
    {
        private readonly IDbRepository _repository;

        public DebtorController(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
             var debtors = await _repository.GetAllDebtors();

            return View(debtors);
        }

        [HttpPost]
        public async Task<IActionResult> AddDebtor(Debtor debtor)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddOneDebtor(new Debtor
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = debtor.Name
                });
              
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDebtor(Debtor debtor)
        {
            await _repository.DeleteDebtor(debtor);
            var debtors = await _repository.GetAllDebtors();

            return RedirectToAction("Index", debtors);
        }
    }
}
