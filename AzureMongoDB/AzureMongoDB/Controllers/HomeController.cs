using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using AzureMongoDB.Services.Interfaces;
using AzureMongoDB.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace AzureMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbRepository _repository;

        public HomeController(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string currency = "")
        {
            var debtors = await _repository.GetAllDebtors();
            var credits = await _repository.GetAllCredits(true);

            IEnumerable<CreditPlusDebtorName> creditPlusDebtorNames = new List<CreditPlusDebtorName>();

            if (!string.IsNullOrEmpty(currency))
            {
                creditPlusDebtorNames = credits.Join(debtors, arg => arg.DebtorId, arg => arg.Id,
                        (credit, debtor) => new CreditPlusDebtorName { Credit = credit, DebtorName = debtor.Name })
                    .Where(arg => arg.Credit.Currency == currency);
            }
            else
            {
                creditPlusDebtorNames = credits.Join(debtors, arg => arg.DebtorId, arg => arg.Id,
                    (credit, debtor) => new CreditPlusDebtorName { Credit = credit, DebtorName = debtor.Name });
            }

            var viewModel = new IndexViewModel
            {
                Credits = credits,
                Debtors = debtors,
                CreditPlusDebtorNames = creditPlusDebtorNames,
                NewCredit = new Credit()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCredit(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.NewCredit.Id = Guid.NewGuid().ToString();
                await _repository.AddCredit(viewModel.NewCredit);
            }

            return RedirectToAction("Index");
        }

        public IActionResult GetCurrency(IndexViewModel viewModel)
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index", currency = viewModel.SelectedCurrency }));
        }
    }
}
