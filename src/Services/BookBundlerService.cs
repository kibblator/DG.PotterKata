using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BookBundlerService
    {
        public static IEnumerable<BookBundle> CreateBundles(IEnumerable<Book> books)
        {
            var bundles = new List<BookBundle>();
            foreach (var book in books)
            {
                var bundleMissingBook = FindBundleMissingBook(bundles, book);

                if (bundleMissingBook == null)
                {
                    bundles.Add(BookBundle.CreateNewBundleWithBook(book));
                }
                else
                {
                    bundleMissingBook.Books.Add(book);
                }
            }

            return bundles;
        }

        private static BookBundle FindBundleMissingBook(IEnumerable<BookBundle> bundles, Book book)
        {
            return bundles.FirstOrDefault(b => b.Books.Any(bk => bk.BookId == book.BookId) == false);
        }
    }
}
