using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace test.Services.MovieService
{
    public class MovieService
    {
        private readonly DataContext _context;
        public MovieService(DataContext context)
        {
            _context = context;
        }
        //public async Task<List<Movie>> GetAllMovies()
        //{
        //    var movies = await _context.Movies.ToListAsync();
        //    return movies;
        //}
        /*public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.Include(x=>x.SuperHero).Where(m=>m.Id==id).FirstOrDefaultAsync();
            return movie;
        }
        public async Task<List<Movie>> GetMoviesByIdSuperHero(int id)
        {
            var movies = await _context.Movies.Where(m=>m.SuperHeroId==id).ToListAsync();
            return movies;
        }*/
        public async Task<Movie> AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> UpdateMovie(int id, Movie request)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return null;
            movie.Name= request.Name;
            movie.Min= request.Min;
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return false;
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Movie>> GetMoviesByIdSuperHero(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(string id)
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

        public Task<Movie> AddMovie(string id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
