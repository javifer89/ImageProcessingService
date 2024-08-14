using ImageProcessingService.Models;

namespace ImageProcessingService.Services
{
    public class ImageService
    {
        public async Task<string> TransformImageAsync(Guid imageId, Transformation transformation)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null) throw new Exception("Image not found");

            // Apply transformations using ImageSharp or SkiaSharp
            var transformedImagePath = await _transformationService.ApplyTransformationAsync(image, transformation);

            return transformedImagePath;
        }
    }
}
