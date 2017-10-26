using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AzureMongoDB.Models;

namespace AzureMongoDB.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Debtor> Debtors { get; set; }
        public IEnumerable<Credit> Credits { get; set; }
        public Credit NewCredit { get; set; }
        public string SelectedCurrency { get; set; } = "All";
    }
}
