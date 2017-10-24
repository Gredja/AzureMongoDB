using System;
using MongoDB.Bson.Serialization.Attributes;

namespace AzureMongoDB.Models
{
    public class Credit
    {
        [BsonId]
        public string Id { get; set; }
        public string DebtorId { get; set; }
        public string Currency { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Comment { get; set; }
    }
}
