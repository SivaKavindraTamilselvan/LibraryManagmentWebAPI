using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibraryManagement.Repositories;
 // book  repo for getting the details based on the filters
// usage of linq

public class BookRepository : AbstractRepository<int, Book>,IBookRepository
{
    public BookRepository(LibraryManagementContext libraryManagementContext) : base (libraryManagementContext)
    {
        
    }
    public override Book? Get(int key)
    {
        var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(bs => bs.BookStatus).Where(b => b.BookId == key).FirstOrDefault();
        return book;
    }
    public List<Book> GetBookByTitle(string title)
    {
        var books = libraryManagementContext.Book.Where(b => b.BookTitle == title).Include(bc => bc.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(bs => bs.BookStatus).ToList();
        return books;
    }

    public List<Book> GetBookByAuthor(string author)
    {
        var books = libraryManagementContext.Book.Where(b => b.Author == author).Include(bc => bc.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(bs => bs.BookStatus).ToList();
        return books;
    }
    public override List<Book> GetAll()
    {
        var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(bs => bs.BookStatus).ToList();
        return book;
    }

    public Book? GetBookIdByTitle(string title)
    {
        var book = libraryManagementContext.Book.Where(b => b.BookTitle == title).FirstOrDefault();
        return book;
    }

    public int GetNumberOfBookByBookTitle(int id)
    {
        using var transaction = libraryManagementContext.Database.BeginTransaction();
        try
        {
            int count = libraryManagementContext.Database.SqlQuery<int>($"SELECT get_number_of_books_by_book({id}) AS \"Value\"").FirstOrDefault();
            transaction.Commit();
            libraryManagementContext.ChangeTracker.Clear();
            return count;
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
    public int GetNumberOfBookByISBN(string isbn)
    {
        using var transaction = libraryManagementContext.Database.BeginTransaction();
        try
        {
            int count = libraryManagementContext.Database.SqlQuery<int>($"SELECT get_number_of_books_by_isbn({isbn}) AS \"Value\"").FirstOrDefault();
            transaction.Commit();
            libraryManagementContext.ChangeTracker.Clear();
            return count;
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        return 0;
    }

    public Book? GetBooksReport(int id)
    {
        var book = libraryManagementContext.Book.Include(b => b.BookCategory).Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(bs => bs.BookStatus)
        .Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(br => br.Borrowings).ThenInclude(br => br.BorrowingStatus)
        .Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(br => br.Borrowings).ThenInclude(f => f.Fines).ThenInclude(fc => fc.FineCategory)
        .Include(bi => bi.BookISBNs).ThenInclude(bc => bc.BookCopies).ThenInclude(br => br.Borrowings).ThenInclude(f => f.Fines).ThenInclude(d => d.DamagedBook).ThenInclude(dl => dl!.DamagedLevel)
        .FirstOrDefault(b => b.BookId == id);
        return book;
    }
}