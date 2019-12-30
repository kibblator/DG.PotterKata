using System.Collections.Generic;
using System.Linq;
using DG.PotterKata.Models;

namespace DG.PotterKata.Services
{
    public class BasketService
    {
        public decimal CalcCost(List<Book> books)
        {
            var balancedBundles = BookBundlerService.CreateBundles(books, true).ToList();
            var unbalancedBundles = BookBundlerService.CreateBundles(books, false).ToList();

            var balancedDiscount = balancedBundles.Sum(bb => DiscountService.GetDiscount(bb.Books.Count));
            var unbalancedDiscount = unbalancedBundles.Sum(ub => DiscountService.GetDiscount(ub.Books.Count));

            var selectedBundle = balancedDiscount < unbalancedDiscount ? balancedBundles : unbalancedBundles;

            return selectedBundle.Sum(bu => BundleCostService.CalcBundleCostWithDiscount(bu));
        }
    }
}
