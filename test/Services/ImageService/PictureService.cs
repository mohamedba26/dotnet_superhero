using Microsoft.EntityFrameworkCore;
using test.ModelsDTO;

namespace test.Services.ImageService
{
    public class PictureService 
    {
        private readonly DataContext _context;
        public PictureService(DataContext context)
        {
            _context = context;
        }
        public async Task<Picture> GetImageById(int id)
        {
            var image = await _context.Pictures.FindAsync(id);
            return image;
        }
        public async Task<Picture> AddImage(Picture image)
        {
            await _context.Pictures.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<Picture> UpdateImage(int id, string base64)
        {
            var image = await _context.Pictures.FindAsync(id);
            image.Photo = base64;
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<bool> DeleteImage(int id)
        {
            var image = await _context.Pictures.FindAsync(id);
            return true;
        }
    }
}
