using MongoDB.Bson.Serialization.Attributes;

namespace AzureMongoDB.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
