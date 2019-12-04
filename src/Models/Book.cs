namespace DG.PotterKata.Models
{
    public class Book
    {
        public Book(int bookId)
        {
            BookId = bookId;
        }
        public int BookId { get; private set; }
    }
}