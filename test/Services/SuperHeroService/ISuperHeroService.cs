namespace test.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetHeroById(string id);
        Task<SuperHero> AddHero(SuperHero hero);
        Task<SuperHero> UpdateHero(string id, SuperHero request);
        Task<bool> DeleteHero(string id);
    }
}
