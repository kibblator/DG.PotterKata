using System.Collections.Generic;

namespace DG.PotterKata.Models
{
    public class BookBundle
    {
        public BookBundle(List<Book> books)
        {
            Books = books;
        }

        public static BookBundle CreateNewBundleWithBook(Book book)
        {
            return new BookBundle(new List<Book>{book});
        }

        public List<Book> Books { get; private set; }
    }
}
