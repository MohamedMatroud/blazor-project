using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Borrowbooks> Borrowbooks { get; set; } = null!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Borrowbooks>(entity =>
            {
                entity.ToTable("Borrowbooks");

                entity.Property(e => e.BorrowbookID).HasColumnName("BorrowbookID");
                entity.HasKey(e => e.BorrowbookID);


            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookID).HasColumnName("BookID");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Author)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.BookDescribation)
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });
         

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
