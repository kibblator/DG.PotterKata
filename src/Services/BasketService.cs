using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BasketService
    {
        public class BookBundle
        {
            public List<Book> Books { get; set; }
        }

        public decimal CalcCost(List<Book> books)
        {
            const decimal bookCost = 8m;
            var total = 0m;

            var bundles = CreateBundles(books);
            foreach (var bookBundle in bundles)
            {
                total += bookCost * bookBundle.Books.Count * DiscountService.CalcDiscount(bookBundle);
            }

            return total;
        }

        private IEnumerable<BookBundle> CreateBundles(IEnumerable<Book> books)
        {
            var bundles = new List<BookBundle>();
            foreach (var book in books)
            {
                var bundleMissingBook = bundles.FirstOrDefault(b => b.Books
                    .Any(bk => bk.BookId == book.BookId) == false);

                if (bundleMissingBook == null)
                {
                    bundles.Add(new BookBundle
                    {
                        Books = new List<Book>
                        {
                            book
                        }
                    });
                }
                else
                {
                    bundleMissingBook.Books.Add(book);
                }
            }

            return bundles;
        }
    }
}
