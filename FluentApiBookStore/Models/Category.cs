using System.Diagnostics.Eventing.Reader;

namespace FluentApiBookStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string ?Name { get; set; }
        public string ?UrlHandle { get; set; } //örn : bilim-kurgu

        public List<Book> ?Books { get; set; }
    }
}