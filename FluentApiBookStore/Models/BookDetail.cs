namespace FluentApiBookStore.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string ?ISBN { get; set; }
        public int PageCount { get; set; }
        public string ?CoverImageUrl { get; set; }


        public int BookId { get; set; }
        public Book ?Book { get; set; }
    }
}