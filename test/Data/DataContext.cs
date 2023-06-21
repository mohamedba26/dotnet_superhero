using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace test.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SuperHero>()
        //        .HasOne(s => s.Photo)
        //        .WithOne(i => i.SuperHero)
        //        .HasForeignKey<Picture>(p => p.Id);
        //}
    }
}
