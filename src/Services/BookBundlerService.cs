using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BookBundlerService
    {
        public static IEnumerable<BookBundle> CreateBundles(IEnumerable<Book> books, bool balanced)
        {
            var bundles = new List<BookBundle>();
            foreach (var book in books)
            {
                var bundleMissingBook = FindBundleMissingBook(bundles, book, balanced);

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

        private static BookBundle FindBundleMissingBook(IEnumerable<BookBundle> bundles, Book book, bool balanced)
        {
            return balanced
                ? bundles.OrderBy(bu => bu.Books.Count)
                    .FirstOrDefault(b => b.Books.Any(bk => bk.BookId == book.BookId) == false)
                : bundles.OrderByDescending(bu => bu.Books.Count)
                    .FirstOrDefault(b => b.Books.Any(bk => bk.BookId == book.BookId) == false);
        }
    }
}
