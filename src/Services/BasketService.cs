using System.Collections.Generic;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BasketService
    {
        public decimal CalcCost(List<Book> books)
        {
            const decimal bookCost = 8m;
            var subTotal = books.Count * bookCost;

            subTotal = DiscountService.CalcDiscount(books, subTotal);

            return subTotal;
        }
    }
}
