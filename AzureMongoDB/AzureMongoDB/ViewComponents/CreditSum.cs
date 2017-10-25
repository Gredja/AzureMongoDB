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
            var credits = _dbRepository.GetAllActiveCredits().Result;
            return $"Вам должны {credits.Sum(x => x.Amount)}";
        }
    }
}
