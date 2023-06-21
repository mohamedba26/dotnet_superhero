using Microsoft.OpenApi.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace test.models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Min { get; set; } = 0;
    }
}
