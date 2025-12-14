using FluentApiBookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiBookStore.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
           builder.HasKey(a=> a.Id);
           builder.Property(a=>a.FullName)
           .IsRequired().HasMaxLength(100);
        }
    }
}