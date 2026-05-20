using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibraryManagement.Repositories;

// book catgory repo for getting the details based on the filters
// usage of linq

public class BookCategoryRepository : AbstractRepository<int, BookCategory>
{
    public override BookCategory? Get(int key)
    {
        var bookCategory = libraryManagementContext.BookCategory.Where(b=>b.BookCategoryId == key).FirstOrDefault();
        return bookCategory;
    }
    public List<BookCategory> GetBookByCategory(int id)
    {
        var booklist = libraryManagementContext.BookCategory.Where(b=>b.BookCategoryId==id).Include(b=>b.Books).ToList();
        return booklist;
    }

    public int GetNumberOfBookByCategory(int id)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            int count = context.Database.SqlQuery<int>($"SELECT get_number_of_books_by_category({id}) AS \"Value\"").FirstOrDefault();
            transaction.Commit();
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
}