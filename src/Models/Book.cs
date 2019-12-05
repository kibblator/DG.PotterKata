namespace DG.PotterKata.Models
{
    public class Book
    {
        public Book(int bookId)
        {
            BookId = bookId;
            BookCost = 8m;
        }
        public int BookId { get; private set; }
        public decimal BookCost { get; private set; }
    }
}