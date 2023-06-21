using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Services.ImageService;
using test.Services.SuperHeroService;

namespace test.Controllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly ISuperHeroService _superHeroService;
        public PhotoController(IPictureService pictureService, ISuperHeroService superHeroService)
        {
            _pictureService = pictureService;
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPhoto(string id)
        {
            var image=await _pictureService.GetImageById(id);
            if(image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }
        [HttpPost("Addphoto")]
        public async Task<IActionResult> Addphoto(string id, IFormFile photo)
        {
            if (photo == null)
            {
                return NotFound();
            }
            string imgBs64 = "";
            using (var ms = new MemoryStream())
            {
                await photo.CopyToAsync(ms);
                imgBs64 = Convert.ToBase64String(ms.ToArray());
            }
            var s = await _superHeroService.GetHeroById(id);
            if (s == null)
            {
                return NotFound();
            }
            var img = await _pictureService.AddImage(id,imgBs64);
            return Ok(img);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatëPhoto(string id,IFormFile photo)
        {
            var result=await _pictureService.GetImageById(id);
            if (photo == null || result==null)
            {
                return NotFound();
            }
            string imgBs64 = "";
            using (var ms = new MemoryStream())
            {
                await photo.CopyToAsync(ms);
                imgBs64 = Convert.ToBase64String(ms.ToArray());
            }
            await _pictureService.UpdateImage(id, imgBs64);
            return Ok(imgBs64);
        }
        [HttpDelete]
        public async Task<IActionResult>deleteImage(string id)
        {
            var result = await _pictureService.GetImageById(id);
            if (result == null)
            {
                return NotFound();
            }
            await _pictureService.DeleteImage(id);
            return Ok("image deleted");
        }
    }
}
