using System.Threading.Tasks;
using AzureMongoDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureMongoDB.Controllers
{
    public class RepaysController : Controller
    {
        private readonly IDbRepository _repository;

        public RepaysController(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var debtors = await _repository.GetAllDebtors();
            var credits = await _repository.GetAllCredits(false);


            return View();
        }
    }
}
