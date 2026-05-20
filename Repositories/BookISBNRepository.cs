using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

// book isbn repo for getting the details based on the filters
// usage of  linq

public class BookISBNRepository : AbstractRepository<int, BookISBN>
{
    public override BookISBN? Get(int key)
    {
        var book = libraryManagementContext.BookISBN.Include(bn=>bn.Book).Include(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b=>b.BookISBNId == key).FirstOrDefault();
        return book;
    }
    public List<BookISBN> GetBookByISBNNumber(string number)
    {
        var book = libraryManagementContext.BookISBN.Include(bn=>bn.Book).Include(bc=>bc.BookCopies).ThenInclude(bs=>bs.BookStatus).Where(b=>b.ISBN == number).ToList();
        return book;
    }
}