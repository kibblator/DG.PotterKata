using System;
using System.Collections.Generic;

namespace DG.PotterKata
{
    public class Basket
    {
        public decimal CalcCost(List<Book> book)
        {
            const decimal bookCost = 8m;
            return book.Count * bookCost;
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
