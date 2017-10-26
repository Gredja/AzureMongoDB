using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using MongoDB.Driver;

namespace AzureMongoDB.Services.Interfaces
{
    public interface IDbRepository
    {
        Task<IEnumerable<Debtor>> GetAllDebtors();
        Task AddOneDebtor(Debtor debtor);
        Task<DeleteResult> DeleteDebtor(Debtor debtor);
        Task<UpdateResult> UpdateDebtor(Debtor debtor);
        Task<IEnumerable<Credit>> GetAllCredits(bool active);
        Task<IEnumerable<Credit>> GetCreditsByDebtor(Debtor debtor);
        Task<DeleteResult> DeleteCredit(Credit credit);
        Task AddCredit(Credit credit);
        Task<UpdateResult> UpdateCredit(Credit credit);
    }
}
