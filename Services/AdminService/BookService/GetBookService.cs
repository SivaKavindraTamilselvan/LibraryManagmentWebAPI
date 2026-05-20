using LibraryManagement.Exceptions;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// get services added for the book created
// include the book,book isbn,book copy,category
public partial class AdminService
{
    public List<Book> GetAllBooks()
    {
        var bookList = bookRepository.GetAllBooks();
        return bookList;
    }
    public Book? GetBookByBookId(int id)
    {
        var book = bookRepository.Get(id);
        return book;
    }

    public List<Book> GetBookByBookTitle(string Title)
    {
        var book = bookRepository.GetBookByTitle(Title);
        return book;
    }
    public List<Book> GetBookByBookAuthor(string author)
    {
        var booklist = bookRepository.GetBookByAuthor(author);
        return booklist;
    }
    public List<BookISBN> GetBookByISBNNumber(string number)
    {
        var book = bookISBNRepository.GetBookByISBNNumber(number);
        return book;
    }

    public BookCopy? GetBookByCopyNumber(string CopyNumber)
    {
        var book = bookCopyRepository.GetBookByCopyNumber(CopyNumber);
        return book;
    }
    public List<BookCategory> GetBookByCategory(int id)
    {
        var booklist = bookCategoryRepository.GetBookByCategory(id);
        return booklist;
    }

    public List<BookCopy> GetBookByStatus(int id)
    {
        var booklist = bookCopyRepository.GetBookByStatus(id);
        return booklist;
    }

    public Book? GetBookIdByTitle(string title)
    {
        var book = bookRepository.GetBookIdByTitle(title);
        return book;
    }

    public int GetNumberOfBookByCategory(int id)
    {
        return bookCategoryRepository.GetNumberOfBookByCategory(id);
    }
    public int GetNumberOfBookByBookTitle(string title)
    {
        var book = bookRepository.GetBookIdByTitle(title);
        if(book == null)
        {
            throw new InvalidBookException("No Book Is Found With The Title");
        }
        return bookRepository.GetNumberOfBookByBookTitle(book.BookId);
    }
    public int GetNumberOfBookByISBN(string isbn)
    {
        return bookRepository.GetNumberOfBookByISBN(isbn);
    }
}