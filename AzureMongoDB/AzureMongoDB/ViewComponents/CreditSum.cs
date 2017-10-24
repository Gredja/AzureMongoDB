using System.Linq;
using System.Threading.Tasks;
using AzureMongoDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureMongoDB.ViewComponents
{
    public class CreditSum : ViewComponent
    {
        private readonly ICreditDbRepository _creditRepository;

        public CreditSum(ICreditDbRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public async Task<string> Invoke()
        {
            var credits = await _creditRepository.GetAllCredits();

            return $"Вам должны {credits.Sum(x => x.Amount)}";
        }
    }
}
