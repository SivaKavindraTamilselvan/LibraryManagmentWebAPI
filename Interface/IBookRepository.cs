using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;
public interface IBookRepository : IRepository<int,Book>
{
    public List<Book> GetBookByTitle(string title);
    public List<Book> GetBookByAuthor(string author);
    public Book? GetBookIdByTitle(string title);
    public int GetNumberOfBookByBookTitle(int id);
    public int GetNumberOfBookByISBN(string isbn);
    public Book? GetBooksReport(int id);
}