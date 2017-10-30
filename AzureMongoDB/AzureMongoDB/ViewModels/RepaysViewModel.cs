using System.Collections.Generic;
using AzureMongoDB.Models;

namespace AzureMongoDB.ViewModels
{
    public class RepaysViewModel
    {
        public IEnumerable<MoneyPlusDebtorName> RepaysPlusDebtorNames { get; set; }
    }
}
