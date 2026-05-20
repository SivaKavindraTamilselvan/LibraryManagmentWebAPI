using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;
public interface IBookCopyRepository : IRepository<int,BookCopy>
{
    public BookCopy? GetBookByCopyNumber(string CopyNumber);
    public List<BookCopy> GetBookByStatus(int id);
}