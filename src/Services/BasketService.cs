using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BasketService
    {
        public decimal CalcCost(List<Book> books)
        {
            var bundles = BookBundlerService.CreateBundles(books);

            return bundles.Sum(CalcBundleCostWithDiscount);
        }

        private static decimal CalcBundleCostWithDiscount(BookBundle bookBundle)
        {
            return CalcBaseCost(bookBundle.Books) * DiscountService.GetDiscount(bookBundle);
        }

        private static decimal CalcBaseCost(IEnumerable<Book> books)
        {
            return books.Sum(b => b.BookCost);
        }
    }
}
