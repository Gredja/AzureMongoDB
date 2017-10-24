using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMongoDB.Models;
using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureMongoDB.Services
{
    public class DbRepository : IDbRepository
    {
        private readonly MongoDbContex _context;

        public DbRepository(IOptions<Settings> settings)
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
            await DeleteCreditsByDebtor(debtor);

            var filter = Builders<Debtor>.Filter.Eq("Id", debtor.Id);
            return await _context.Debtors.DeleteOneAsync(filter);
        }

        public async Task<UpdateResult> UpdateDebtor(Debtor debtor)
        {
            var filter = Builders<Debtor>.Filter.Eq(s => s.Id, debtor.Id);
            var update = Builders<Debtor>.Update.Set(s => s, debtor).CurrentDate(s => s);

            return await _context.Debtors.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Credit>> GetAllCredits()
        {
            return await _context.Credits.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Credit>> GetCreditsByDebtor(Debtor debtor)
        {
            var filter = Builders<Credit>.Filter.Eq(s => s.DebtorId, debtor.Id);
            return await _context.Credits.Find(filter).ToListAsync();
        }

        public async Task<DeleteResult> DeleteCredit(Credit credit)
        {
            var filter = Builders<Credit>.Filter.Eq("Id", credit.Id);
            return await _context.Credits.DeleteOneAsync(filter);
        }

        private async Task<DeleteResult> DeleteCreditsByDebtor(Debtor debtor)
        {
            var filter = Builders<Credit>.Filter.Eq("DebtorId", debtor.Id);
            return await _context.Credits.DeleteManyAsync(filter);
        }
    }
}
