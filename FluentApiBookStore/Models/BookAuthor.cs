using FluentApiBookStore.Model;

namespace FluentApiBookStore.Models
{
    public class BookAuthor
    {
        // Composite Key (Birleşik Anahtar) olacak: Hem BookId hem AuthorId
        public int BookId { get; set; }
        public Book ?Book { get; set; }

        public int AuthorId { get; set; }
        public Author ?Author { get; set; }
    }
}