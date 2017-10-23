﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using MongoDB.Driver;

namespace AzureMongoDB.Services.Interfaces
{
    public interface IMongoDbRepository
    {
        Task<IEnumerable<Debtor>> GetAllDebtors();
        Task AddOneDebtor(Debtor debtor);
        Task<DeleteResult> DeleteDebtor(Debtor debtor);
    }
}
