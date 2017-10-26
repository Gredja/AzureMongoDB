using System.Linq;
using AzureMongoDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureMongoDB.ViewComponents
{
    public class CreditSum : ViewComponent
    {
        private readonly IDbRepository _dbRepository;

        public CreditSum(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public string Invoke()
        {
            var result = string.Empty;
            var credits = _dbRepository.GetAllCredits(true).Result;

            if (credits != null)
            {
                result = $"Вам должны: \n USD - {credits.Where(x => x.Currency == "USD").Sum(s => s.Amount)} \n" +
                         $"EUR - {credits.Where(x => x.Currency == "EUR").Sum(s => s.Amount)} \n" +
                         $"BYN - {credits.Where(x => x.Currency == "BYN").Sum(s => s.Amount)} \n";
            }

            return result;
        }
    }
}
