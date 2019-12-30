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

            return bundles.Sum(bu => BundleCostService.CalcBundleCostWithDiscount(bu));
        }
    }
}
