using MongoDB.Bson;
using MongoDB.Driver;
using System.Buffers.Text;
using test.models;

namespace test.Services.ImageService
{
    public class PictureMongoDbService : IPictureService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _db = null;
        private readonly IMongoCollection<SuperHero> _superHeroTable = null;
        public PictureMongoDbService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _db = _mongoClient.GetDatabase("testdb");
            _superHeroTable = _db.GetCollection<SuperHero>("superheros");
        }

        public async Task<string> GetImageById(string id)
        {
            var hero = _superHeroTable.Find(x => x.Id==id).FirstOrDefault();
            return hero.Photo;
        }

        public async Task<string> AddImage(string id,string base64)
        {
            var hero = _superHeroTable.Find(x => x.Id == id).FirstOrDefault();
            if (hero == null)
                return null;
            hero.Photo = base64;
            _superHeroTable.ReplaceOne(h => h.Id == hero.Id, hero);
            return base64;
        }

        public async Task<string> UpdateImage(string id, string base64)
        {
            var hero = _superHeroTable.Find(x => x.Id == id).FirstOrDefault();
            if (hero == null)
                return null;
            hero.Photo= base64;
            _superHeroTable.ReplaceOne(h => h.Id == hero.Id, hero);
            return base64;
        }

        public async Task<bool> DeleteImage(string id)
        {
            var hero = _superHeroTable.Find(x => x.Id == id).FirstOrDefault();
            if (hero == null)
                return false;
            hero.Photo = "";
            _superHeroTable.ReplaceOne(h => h.Id == hero.Id, hero);
            return true;
        }

    }
}
