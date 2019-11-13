using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobiliNew.Web.Data.Models
{
    public partial class corsodotnetContext : DbContext
    {
        public corsodotnetContext()
        {
        }

        public corsodotnetContext(DbContextOptions<corsodotnetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=AMILONDEV;Database=corsodotnet;User Id=corsosql; Password=corsosqlpwd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories", "ivan1");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "ivan1");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Categories");
            });
        }
    }
}
