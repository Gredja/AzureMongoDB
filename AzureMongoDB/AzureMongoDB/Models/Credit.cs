using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AzureMongoDB.Models
{
    public class Credit
    {
        [BsonId]
        public string Id { get; set; }

        public string DebtorId { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool Disabled { get; set; }

        public string Comment { get; set; }
    }
}
