namespace LibraryManagement.Models;

public class BookCopy
{
    public int BookCopyId { get; set; }
    public int BookISBNId { get; set; }
    public BookISBN? BookISBN { get; set; }
    public string CopyNumber { get; set; } = string.Empty;
    public int BookStatusId { get; set; }
    public BookStatus? BookStatus { get; set; }

    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<DamagedBook> DamagedBooks { get; set; } = new List<DamagedBook>();

    public override string ToString()
    {
        return $"BookCopyID : {BookCopyId}\nBookCopyNumber : {CopyNumber}";
    }
    public string GetAllBookCopyByStatus()
    {
        string book = ToString() + "\n" + $"BookStatus : {BookStatus?.BookStatusName}";
        return book;
    }
    public string GetAllBookCopy()
    {
        string book = ToString() + "\n" + $"BookISBNNumber : {BookISBN?.ISBN}\n" + $"BookStatus : {BookStatus?.BookStatusName}";
        return book;
    }

    public string GetAllBookCopyByCopyNumber()
    {
        string book = ToString() + "\n" + $"BookISBNNumber : {BookISBN?.ISBN}\n" + $"BookStatus : {BookStatus?.BookStatusName}\n";
        book = book + $"BookPublishedYear : {BookISBN?.PublishedYear}\nEdition : {BookISBN?.Edition}\n";
        book = book + $"BookTitle : {BookISBN?.Book?.BookTitle}\nBookAuthor : {BookISBN?.Book?.Author}";
        return book;
    }
}