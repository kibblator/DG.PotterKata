using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BasketService
    {
        public decimal CalcCost(List<Book> books)
        {
            const decimal bookCost = 8m;

            var bundles = CreateBundles(books);

            return bundles.Sum(bookBundle => CalcBundleCostWithDiscount(bookCost, bookBundle));
        }

        private static IEnumerable<BookBundle> CreateBundles(IEnumerable<Book> books)
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
            return bundles.FirstOrDefault(b => b.Books
                                                   .Any(bk => bk.BookId == book.BookId) == false);
        }

        private static decimal CalcBundleCostWithDiscount(decimal bookCost, BookBundle bookBundle)
        {
            return CalcBaseCost(bookCost, bookBundle.Books.Count) * DiscountService.GetDiscount(bookBundle);
        }

        private static decimal CalcBaseCost(decimal bookCost, int quantity)
        {
            return bookCost * quantity;
        }
    }
}
