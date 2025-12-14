using FluentApiBookStore.Model;
using FluentApiBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiBookStore
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        // DÜZELTME: ModuleBuilder -> ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.Property(c => c.UrlHandle).HasColumnName("Slug");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired();
                entity.Property(b => b.Price).HasPrecision(18, 2);

                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(bd => bd.Id);
                entity.HasOne(bd => bd.Book)
                      .WithOne(b => b.BookDetail)
                      .HasForeignKey<BookDetail>(bd => bd.BookId);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(ba => new { ba.BookId, ba.AuthorId });

                entity.HasOne(ba => ba.Book)
                      .WithMany(b => b.BookAuthors)
                      .HasForeignKey(ba => ba.BookId);

                entity.HasOne(ba => ba.Author)
                      .WithMany(a => a.BookAuthors)
                      .HasForeignKey(ba => ba.AuthorId);
            });
        }
    }
}