using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace test.Services.MovieService
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesByIdSuperHero(string id);
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(string id);
        Task<Movie> AddMovie(string id,Movie movie);
        Task<Movie> UpdateMovie(string id, Movie movieRequest);
        Task<bool> DeleteMovie(string id);
    }
}
