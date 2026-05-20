namespace LibraryManagement.Models;

public class Book
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int BookCategoryId { get; set; }
    public BookCategory? BookCategory { get; set; }
    public ICollection<BookISBN> BookISBNs { get; set; } = new List<BookISBN>();
    public override string ToString()
    {
        string basicBookDetails = "--------- Basic Book Details ---------";
        return basicBookDetails + "\n\n" + $"BookId : {BookId}\nBookTitle : {BookTitle}\nAuthor : {Author}";
    }

    public string GetBooksByCategory()
    {
        string book = ToString() + "\n" + $"BookCategoryId : {BookCategoryId}\nBookCategoryName : {BookCategory?.BookCategoryName}";
        return "\n\n" + book;
    }

    public string GetAllBooks()
    {
        string isbnDetails = BookISBNs.Any() ? string.Join("\n\n", BookISBNs.Select(b => b.GetAllBookISBN())) : "No Book ISBN Available";
        return GetBooksByCategory() + "\n\n\n" + isbnDetails;
    }
}