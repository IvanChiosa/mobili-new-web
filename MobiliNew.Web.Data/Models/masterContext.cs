using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobiliNew.Web.Data.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<EmailQueue> EmailQueue { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-PP69MFU0;Database=master; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModification).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Surname).IsRequired();
            });

            modelBuilder.Entity<EmailQueue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BccAddress)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DateLoading).HasColumnType("datetime");

                entity.Property(e => e.DateProcessed).HasColumnType("datetime");

                entity.Property(e => e.FromAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MailBody)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.MailObject)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IdCategories).HasColumnName("IdCategories");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Categories");
            });
        }
    }
}
