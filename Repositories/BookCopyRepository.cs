using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

// book copy repo for getting the details based on the filters
// usage of linq

public class BookCopyRepository : AbstractRepository<int, BookCopy>
{
    public override BookCopy? Get(int key)
    {
        var book = libraryManagementContext.BookCopy.Include(bs=>bs.BookISBN).ThenInclude(b=>b!.Book).Include(bs=>bs.BookStatus).Where(b=>b.BookCopyId == key).FirstOrDefault();
        return book;
    }

    public BookCopy? GetBookByCopyNumber(string CopyNumber)
    {
        var book = libraryManagementContext.BookCopy.Include(bs=>bs.BookISBN).ThenInclude(b=>b!.Book).Include(bs=>bs.BookStatus).Where(b=>b.CopyNumber == CopyNumber).FirstOrDefault();
        return book;
    }

    public List<BookCopy> GetBookByStatus(int id)
    {
        var book = libraryManagementContext.BookCopy.Include(b=>b.BookISBN).ThenInclude(b=>b!.Book).Include(bs=>bs.BookStatus).Where(b=>b.BookStatusId == id).ToList();
        return book;
    }
}