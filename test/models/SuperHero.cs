using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace test.models
{
    public class SuperHero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public Collection<Movie> Movies { get; set; } = new Collection<Movie>();
        public string Photo { get; set; }
        
        //public virtual Picture Photo { get; set; }
    }
}
