using Microsoft.EntityFrameworkCore;
using static ImageProcessingService.Models.DbModels;

namespace ImageProcessingService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Transformation> Transformations { get; set; }
        public DbSet<ProcessedImage> ProcessedImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Opcional: Configurar relaciones y restricciones adicionales.
            modelBuilder.Entity<Image>()
                .HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Transformation>()
                .HasOne(t => t.Image)
                .WithMany(i => i.Transformations)
                .HasForeignKey(t => t.ImageId);

            modelBuilder.Entity<ProcessedImage>()
                .HasOne(pi => pi.Image)
                .WithMany(i => i.ProcessedImages)
                .HasForeignKey(pi => pi.ImageId);

            modelBuilder.Entity<ProcessedImage>()
                .HasOne(pi => pi.Transformation)
                .WithMany(t => t.ProcessedImages)
                .HasForeignKey(pi => pi.TransformationId);
        }
    }
}
