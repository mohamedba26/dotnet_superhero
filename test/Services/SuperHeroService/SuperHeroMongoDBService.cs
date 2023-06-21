using MongoDB.Bson;
using MongoDB.Driver;

namespace test.Services.SuperHeroService
{
    public class SuperHeroMongoDBService : ISuperHeroService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _db=null;
        private readonly IMongoCollection<SuperHero> _superHeroTable=null;
        public SuperHeroMongoDBService() 
        {
            _mongoClient= new MongoClient("mongodb://localhost:27017");
            _db = _mongoClient.GetDatabase("testdb");
            _superHeroTable = _db.GetCollection<SuperHero>("superheros");
        }


        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var superHeroes = _superHeroTable.AsQueryable().ToList();
            return superHeroes;
        }

        public async Task<SuperHero> GetHeroById(string id)
        {
            var superHeroes = _superHeroTable.Find(x=>x.Id==id).FirstOrDefault();
            return superHeroes;
        }
        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            hero.Id= ObjectId.GenerateNewId().ToString();
            _superHeroTable.InsertOne(hero);
            return hero;
        }

        public async Task<SuperHero> UpdateHero(string id, SuperHero heroRequest)
        {
            var superHero = _superHeroTable.Find(x => x.Id == id).FirstOrDefault();
            if (superHero == null)
                return null;
            heroRequest.Id = superHero.Id;
            _superHeroTable.ReplaceOne(x => x.Id == id, heroRequest);
            return superHero;
        }
        public async Task<bool> DeleteHero(string id)
        {
            var superHero = _superHeroTable.Find(x => x.Id == id);
            if (superHero == null)
                return false;
            _superHeroTable.DeleteOne(x=>x.Id==id);
            return true;
        }
    }
}
