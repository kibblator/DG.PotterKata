using System.Collections.Generic;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public static class DiscountService
    {
        private static readonly Dictionary<int, decimal> DiscountAmounts = new Dictionary<int, decimal>
        {
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m},
            {5, 0.75m}
        };

        public static decimal GetDiscount(BookBundle bundle)
        {
            return DiscountAmounts[bundle.Books.Count];
        }
    }
}
