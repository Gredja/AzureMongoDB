using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AzureMongoDB.Models
{
    public class Debtor
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
