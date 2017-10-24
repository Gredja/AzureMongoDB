using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using MongoDB.Driver;

namespace AzureMongoDB.Services.Interfaces
{
    public interface IDebtorDbRepository
    {
        Task<IEnumerable<Debtor>> GetAllDebtors();
        Task AddOneDebtor(Debtor debtor);
        Task<DeleteResult> DeleteDebtor(Debtor debtor);
        Task<UpdateResult> UpdateDebtor(Debtor debtor);
    }
}
