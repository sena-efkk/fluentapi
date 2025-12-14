namespace FluentApiBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }

        public int CategoryId { get; set; }
        public Category ?Category { get; set; }

        // 1-1 İlişkisi
        public BookDetail ?BookDetail { get; set; }

        // N-N İlişkisi
        public List<BookAuthor> ?BookAuthors { get; set; }
    }
}