namespace test.ModelsDTO
{
    public class SuperHeroDTO
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Photo { get; set; }

        public static SuperHeroDTO ToSuperHeroDTO(SuperHero sp)
        {
            return new SuperHeroDTO
            {
                Id = sp.Id,
                Name = sp.Name,
                FirstName = sp.FirstName,
                LastName = sp.LastName,
                Place = sp.Place,
                Photo = sp.Photo
            };
        }
        public SuperHero ToSuperHero()
        {
            return new SuperHero
            {
                Id = Id,
                Name = Name,
                FirstName = FirstName,
                LastName = LastName,
                Place = Place,
                Photo= Photo
            };
        }
    }
}
