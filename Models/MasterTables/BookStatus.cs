namespace LibraryManagement.Models;

public class BookStatus
{
    public int BookStatusId {get;set;}
    public string BookStatusName {get;set;} = string.Empty;
    public ICollection<BookCopy> BookCopies {get;set;} = new List<BookCopy>();
}