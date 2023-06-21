using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace test.Services.SuperHeroService
{
    public class SuperHeroService 
    {
        /*private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.Include(x=>x.Movies).ToListAsync();
            if(heroes!=null)
                foreach (var hero in heroes)
                    foreach (var m in hero.Movies)
                        m.SuperHero = null;
            return heroes;
        }
        public async Task<SuperHero> GetHeroById(string id)
        {
            var hero = await _context.SuperHeroes.Include(x=>x.Movies).Where(h=>h.Id == id).Include(x => x.Photo).FirstOrDefaultAsync();
            if (hero != null)
                foreach(var m in hero.Movies)
                    m.SuperHero = null;
            return new SuperHero();
        }
        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return hero;
        }
        public async Task<SuperHero> UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            await _context.SaveChangesAsync();
            return hero;
        }
        public async Task<bool> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return false;
             _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return true;
        }*/
    }
}
