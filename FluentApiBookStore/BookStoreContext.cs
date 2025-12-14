using FluentApiBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection; //

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ESKİ USUL:
            // modelBuilder.Entity<Category>(SİLİNDİ)
            // modelBuilder.Entity<Book> (SİLİNDİ)

            // YENİ USUL (TEK SATIR):
            // Bu komut diyor ki: "Bu proje (Assembly) içindeki IEntityTypeConfiguration
            // interface'ini implemente eden TÜM sınıfları bul ve uygula."
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}