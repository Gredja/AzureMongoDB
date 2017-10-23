using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;

namespace AzureMongoDB.Services.Interfaces
{
    public interface IMongoDbRepository
    {
       Task<IEnumerable<Debtor>> GetAllUsers();
    }
}
