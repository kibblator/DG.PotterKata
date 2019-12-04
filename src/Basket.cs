using System;

namespace DG.PotterKata
{
    public class Basket
    {
        public decimal CalcCost(int quantity)
        {
            var bookCost = 8m;
            return quantity * bookCost;
        }
    }
}
