using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureMongoDB.Services
{
    public class DebtorDbRepository : IDebtorDbRepository
    {
        private readonly MongoDbContex _context = null;

        public DebtorDbRepository(IOptions<Settings> settings)
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

        public async Task<UpdateResult> UpdateDebtor(Debtor debtor)
        {
            var filter = Builders<Debtor>.Filter.Eq(s => s.Id, debtor.Id);
            var update = Builders<Debtor>.Update.Set(s => s, debtor).CurrentDate(s => s);

            return await _context.Debtors.UpdateOneAsync(filter, update);
        }
    }
}
