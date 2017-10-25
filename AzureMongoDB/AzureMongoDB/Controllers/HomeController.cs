using System.Threading.Tasks;
using AzureMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using AzureMongoDB.Services.Interfaces;
using AzureMongoDB.ViewModels;

namespace AzureMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbRepository _repository;

        public HomeController(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var debtors = await _repository.GetAllDebtors();
            var credits = await _repository.GetAllActiveCredits();

            var viewModel = new IndexViewModel { Credits = credits, Debtors = debtors, NewCredit = new Credit() };

            return View(viewModel);
        }

        public async Task<IActionResult> AddCredit(IndexViewModel viewModel)
        {
            return RedirectToAction("Index");
        }

    }
}
