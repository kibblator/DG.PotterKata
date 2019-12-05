using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public static class DiscountService
    {
        private static Dictionary<int, decimal> discountAmounts = new Dictionary<int, decimal>
        {
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m},
            {4, 0.75m}
        };

        public static decimal CalcDiscount(IEnumerable<Book> books, decimal subTotal)
        {
            var total = subTotal * discountAmounts[books.GroupBy(b => b.BookId).Count()];

            return total;
        }
    }
}
