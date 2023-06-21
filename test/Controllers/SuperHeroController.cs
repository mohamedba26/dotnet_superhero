using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Services.MovieService;
using test.Services.SuperHeroService;
using test.ModelsDTO;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        private readonly IMovieService _moviesService;
        public SuperHeroController(ISuperHeroService superHeroService, IMovieService moviesService)
        {
            _superHeroService = superHeroService;
            _moviesService = moviesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok((await _superHeroService.GetAllHeroes()).Select(s=> SuperHeroDTO.ToSuperHeroDTO(s)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(string id)
        {
            var result=await _superHeroService.GetHeroById(id);
            if(result==null)
                return NotFound("SuperHero not Found");
            return Ok(SuperHeroDTO.ToSuperHeroDTO(result));
        }
        [HttpGet("{id}/movies")]
        public async Task<IActionResult> GetHeroMovies(string id)
        {
            var result=await _moviesService.GetMoviesByIdSuperHero(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHeroDTO hero)
        {
            var addedHero = await _superHeroService.AddHero(hero.ToSuperHero());
            if(addedHero == null)
                return StatusCode(500);
            return Ok(SuperHeroDTO.ToSuperHeroDTO(addedHero));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(string id,SuperHeroDTO superHero)
        {
            var result=await _superHeroService.UpdateHero(id, superHero.ToSuperHero());
            if (result == null)
                return StatusCode(500);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(string id)
        {
            bool result= await _superHeroService.DeleteHero(id);
            if(!result)
                return NotFound("SuperHero not Found");
            return Ok(result);
        }
    }
}
