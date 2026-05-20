using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;

public interface IBookISBNRepository : IRepository<int, BookISBN>
{
    public List<BookISBN> GetBookByISBNNumber(string number);
}