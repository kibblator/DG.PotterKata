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
            var subTotal = books.Count * bookCost;

            subTotal = CalcDiscount(books, subTotal);

            return subTotal;
        }

        private static decimal CalcDiscount(IEnumerable<Book> books, decimal subTotal)
        {
            if (books.GroupBy(b => b.BookId).Count() == 2)
            {
                subTotal *= 0.95m;
            }
            else if (books.GroupBy(b => b.BookId).Count() == 3)
            {
                subTotal *= 0.9m;
            }

            return subTotal;
        }
    }
}
