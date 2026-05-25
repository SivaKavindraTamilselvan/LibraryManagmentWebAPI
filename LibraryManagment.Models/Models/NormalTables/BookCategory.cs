namespace LibraryManagement.Models;

public class BookCategory
{
    public int BookCategoryId { get; set; }
    public string BookCategoryName { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();

    public override string ToString()
    {
        return $"BookCategoryId : {BookCategoryId}\nBookCategoryName : {BookCategoryName}";
    }
    public string GetCategoryByBook()
    {
        string bookDetails = Books.Any() ? string.Join("\n\n", Books.Select(b => $"BookId : {b.BookId}\n" + $"BookTitle : {b.BookTitle}\n" + $"Author : {b.Author}")) : "No ISBN Books Available";
        bookDetails = ToString() + "\n\nThe List Of The Books in the Category\n" + bookDetails;
        return bookDetails;
    }
}