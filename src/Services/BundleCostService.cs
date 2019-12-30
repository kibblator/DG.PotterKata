using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public static class BundleCostService
    {
        public static decimal CalcBundleCostWithDiscount(BookBundle bookBundle)
        {
            return CalcBaseCost(bookBundle.Books) * DiscountService.GetDiscount(bookBundle.Books.Count);
        }

        private static decimal CalcBaseCost(IEnumerable<Book> books)
        {
            return books.Sum(b => b.BookCost);
        }
    }
}
