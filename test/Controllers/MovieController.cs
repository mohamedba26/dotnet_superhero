using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.models;
using test.Services.MovieService;
using test.Services.SuperHeroService;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ISuperHeroService _superhoreoService;
        public MovieController(IMovieService movieService, ISuperHeroService superhoreoService)
        {
            _movieService = movieService;
            _superhoreoService = superhoreoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            return Ok(await _movieService.GetAllMovies());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(string id)
        {
            var result = await _movieService.GetMovieById(id);
            if(result==null)
                return NotFound("Movie not Found");
            return Ok(result);
        }

        [HttpGet("{id}/superHero")]
        public async Task<IActionResult> GetMovieByIdSuperHero(string id)
        {
            var result = await _movieService.GetMoviesByIdSuperHero(id);
            if (result == null)
                return NotFound("Movie not Found");
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddMovie(string id,Movie movie)
        {
            var superhero = await _superhoreoService.GetHeroById(id);   
            if(superhero==null)
            {
                return NotFound("SP not Found");
            }
            var addedMovie = await _movieService.AddMovie(id,movie);
            if (addedMovie == null)
                return NotFound("movie has not been added");
            return Ok(addedMovie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(string id, Movie request)
        {
            var result = await _movieService.GetMovieById(id);
            if(result == null)
                return NotFound();
            return Ok(await _movieService.UpdateMovie(id,request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            bool result = await _movieService.DeleteMovie(id);
            if (!result)
                return NotFound("Movie not Found");
            return Ok(result);
        }
    }
}
