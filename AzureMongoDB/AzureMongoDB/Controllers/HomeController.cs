using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureMongoDB.Services.Interfaces;

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

            return View(debtors);
        }


    }
}
