using test.ModelsDTO;

namespace test.Services.ImageService
{
    public interface IPictureService
    {
        Task<string> GetImageById(string id);
        Task<string> AddImage(string id,string base64);
        Task<string> UpdateImage(string id, string base64);
        Task<bool> DeleteImage(string id);
    }
}
