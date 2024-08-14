namespace ImageProcessingService.Models
{
    public class DbModels
    {
        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string Email { get; set; }
            public DateTime CreatedAt { get; set; }

            public ICollection<Image> Images { get; set; }
        }

        public class Image
        {
            public int ImageId { get; set; }
            public int UserId { get; set; }
            public string OriginalURL { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public long Size { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public DateTime CreatedAt { get; set; }

            public User User { get; set; }
            public ICollection<Transformation> Transformations { get; set; }
        }

        public class Transformation
        {
            public int TransformationId { get; set; }
            public int ImageId { get; set; }
            public string TransformationType { get; set; }
            public string Parameters { get; set; }
            public DateTime AppliedAt { get; set; }

            public Image Image { get; set; }
            public ICollection<ProcessedImage> ProcessedImages { get; set; }
        }

        public class ProcessedImage
        {
            public int ProcessedImageId { get; set; }
            public int ImageId { get; set; }
            public int TransformationId { get; set; }
            public string ProcessedURL { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public long Size { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public DateTime CreatedAt { get; set; }

            public Image Image { get; set; }
            public Transformation Transformation { get; set; }
        }

    }
}
