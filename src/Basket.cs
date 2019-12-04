using System.Collections.Generic;
using System.Linq;

namespace DG.PotterKata
{
    public class Basket
    {
        public decimal CalcCost(List<Book> books)
        {
            const decimal bookCost = 8m;
            var subTotal = books.Count * bookCost;

            if (books.GroupBy(b => b.BookId).Count() > 1)
            {
                subTotal *= 0.95m;
            }

            return subTotal;
        }
    }

    public class Book
    {
        public Book(int bookId)
        {
            BookId = bookId;
        }
        public int BookId { get; private set; }
    }
}
