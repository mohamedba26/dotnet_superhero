using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace test.models
{
    public class Picture
    {
        public int Id { get; set; }
        public SuperHero SuperHero { get; set; }
        public string Photo { get; set; } = string.Empty;
    }
}
