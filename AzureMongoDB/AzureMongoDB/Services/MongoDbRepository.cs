using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureMongoDB.Services
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private readonly MongoDbContex _context = null;

        public MongoDbRepository(IOptions<Settings> settings)
        {
            _context = new MongoDbContex(settings);
        }

        public async Task<IEnumerable<Debtor>> GetAllDebtors()
        {
            return await _context.Debtors.Find(_ => true).ToListAsync();
        }

        public async Task AddOneDebtor(Debtor debtor)
        {
            await _context.Debtors.InsertOneAsync(debtor);
        }

        public async Task<DeleteResult> DeleteDebtor(Debtor debtor)
        {
            return await _context.Debtors.DeleteOneAsync(Builders<Debtor>.Filter.Eq("Id", debtor.Id));
        }
    }
}
