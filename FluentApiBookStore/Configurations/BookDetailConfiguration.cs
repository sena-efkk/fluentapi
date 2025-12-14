using FluentApiBookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiBookStore.Configurations
{
    public class BookDetailConfiguration : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.HasKey(bd => bd.Id);
            builder.HasOne(bd => bd.Book)
            .WithOne(b => b.BookDetail)
            .HasForeignKey<BookDetail>(bd => bd.BookId);

        }
    }
}