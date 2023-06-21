using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using NuGet.Versioning;
using System.Collections.ObjectModel;

namespace test.Services.MovieService
{
    public class MovieMongoDbService : IMovieService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _db = null;
        private readonly IMongoCollection<Movie> _MovieTable = null;
        public MovieMongoDbService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _db = _mongoClient.GetDatabase("testdb");
            _MovieTable = _db.GetCollection<Movie>("movies");
        }
        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = _MovieTable.AsQueryable().ToList();
            return movies;
        }

        public Task<List<Movie>> GetMoviesByIdSuperHero(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> AddMovie(string id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(string id, Movie movieRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<Movie> GetMovieById(string id)
        //{
        //    var movies = _MovieTable.Find(h => h.Movies.Any(m => m.Id == id)).Project(x=>x.Movies).FirstOrDefault();
        //    return movies.Where(x=>x.Id == id).FirstOrDefault();
        //}
        //public async Task<Movie> AddMovie(string id,Movie movie)
        //{
        //    var hero = _MovieTable.Find(x => x.Id == id).FirstOrDefault();
        //    if (hero == null)
        //        return null;
        //    movie.Id = ObjectId.GenerateNewId().ToString();
        //    hero.Movies.Add(movie);
        //    _MovieTable.ReplaceOne(x => x.Id == id, hero);
        //    return movie;
        //}

        //public async Task<Movie> UpdateMovie(string id, Movie movieRequest)
        //{
        //    var hero = _MovieTable.Find(h=>h.Movies.Any(m=>m.Id==id)).FirstOrDefault();
        //    if (hero == null)
        //        return null;
        //    movieRequest.Id = id;
        //    var movie=hero.Movies.FirstOrDefault(m=>m.Id==id);
        //    hero.Movies.Remove(movie);
        //    hero.Movies.Add(movieRequest);
        //    _MovieTable.ReplaceOne(h => h.Id == hero.Id, hero);
        //    return movieRequest;
        //}

        //public async Task<List<Movie>> GetMoviesByIdSuperHero(string id)
        //{
        //    var hero = _MovieTable.Find(x => x.Id == id).FirstOrDefault();
        //    if (hero == null)
        //        return null;
        //    return hero.Movies.ToList();
        //}


        //public async Task<bool> DeleteMovie(string id)
        //{
        //    var hero = _MovieTable.Find(h => h.Movies.Any(m => m.Id == id)).FirstOrDefault();
        //    if(hero== null) 
        //        return false;
        //    var movie = hero.Movies.FirstOrDefault(m => m.Id == id);
        //    hero.Movies.Remove(movie);
        //    _MovieTable.ReplaceOne(h => h.Id == hero.Id, hero);
        //    return true;
        //}
    }
}
