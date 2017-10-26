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

        public string Currency { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Amount { get; set; } = 1;

        public DateTime ExpirationDate { get; set; } = DateTime.Now;

        public bool Disabled { get; set; }

        public string Comment { get; set; }
    }
}
