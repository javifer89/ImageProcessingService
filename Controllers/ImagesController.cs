using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessingService.Controllers
{
    public class ImagesController
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest("Invalid image file");

            var imageId = await _imageService.UploadImageAsync(imageFile);
            return Ok(new { ImageId = imageId });
        }
    }
}
