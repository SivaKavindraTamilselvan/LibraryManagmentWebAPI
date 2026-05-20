using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// get services added for the book created
// include the book,book isbn,book copy,category
public partial class BookService
{
    public List<GetBookDTO> GetAllBooks()
    {
        var bookList = bookRepository.GetAll();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("Book List Is Empty");
        }
        return bookList.OrderBy(b => b.BookId).Select(book => new GetBookDTO
        {
            BookId = book.BookId,
            BookTitle = book.BookTitle,
            Author = book.Author,
            BookCategoryName = book?.BookCategory?.BookCategoryName ?? "",
            ISBNs = book?.BookISBNs?.Select(isbn => new GetBookISBNDTO
            {
                BookISBNId = isbn.BookISBNId,
                ISBN = isbn.ISBN,
                PublishedYear = isbn.PublishedYear,
                Edition = isbn.Edition,

                Copies = isbn.BookCopies?.Select(copy => new GetBookCopyDTO
                {
                    BookCopyId = copy.BookCopyId,
                    CopyNumber = copy.CopyNumber,
                    BookStatusId = copy.BookStatusId,
                    BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
                }).ToList() ?? new List<GetBookCopyDTO>()
            }).ToList() ?? new List<GetBookISBNDTO>()

        }).ToList();
    }

    public GetBookDTO? GetBookByBookId(int id)
    {
        var book = bookRepository.Get(id);
        if (book == null)
        {
            return null;
        }
        return new GetBookDTO
        {
            BookId = book.BookId,
            BookTitle = book.BookTitle,
            Author = book.Author,
            BookCategoryName = book?.BookCategory?.BookCategoryName ?? "",
            ISBNs = book?.BookISBNs?.Select(isbn => new GetBookISBNDTO
            {
                BookISBNId = isbn.BookISBNId,
                ISBN = isbn.ISBN,
                PublishedYear = isbn.PublishedYear,
                Edition = isbn.Edition,

                Copies = isbn.BookCopies?.Select(copy => new GetBookCopyDTO
                {
                    BookCopyId = copy.BookCopyId,
                    CopyNumber = copy.CopyNumber,
                    BookStatusId = copy.BookStatusId,
                    BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
                }).ToList() ?? new List<GetBookCopyDTO>()
            }).ToList() ?? new List<GetBookISBNDTO>()
        };
    }
    public List<GetBookDTO> GetBookByBookTitle(string Title)
    {
        var bookList = bookRepository.GetBookByTitle(Title);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("Book Not Found");
        }
        return bookList.OrderBy(b => b.BookId).Select(book => new GetBookDTO
        {
            BookId = book.BookId,
            BookTitle = book.BookTitle,
            Author = book.Author,
            BookCategoryName = book?.BookCategory?.BookCategoryName ?? "",
            ISBNs = book?.BookISBNs?.Select(isbn => new GetBookISBNDTO
            {
                BookISBNId = isbn.BookISBNId,
                ISBN = isbn.ISBN,
                PublishedYear = isbn.PublishedYear,
                Edition = isbn.Edition,

                Copies = isbn.BookCopies?.Select(copy => new GetBookCopyDTO
                {
                    BookCopyId = copy.BookCopyId,
                    CopyNumber = copy.CopyNumber,
                    BookStatusId = copy.BookStatusId,
                    BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
                }).ToList() ?? new List<GetBookCopyDTO>()
            }).ToList() ?? new List<GetBookISBNDTO>()

        }).ToList();
    }
    public List<GetBookDTO> GetBookByBookAuthor(string author)
    {
        var bookList = bookRepository.GetBookByAuthor(author);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("Book Not Found");
        }
        return bookList.OrderBy(b => b.BookId).Select(book => new GetBookDTO
        {
            BookId = book.BookId,
            BookTitle = book.BookTitle,
            Author = book.Author,
            BookCategoryName = book?.BookCategory?.BookCategoryName ?? "",
            ISBNs = book?.BookISBNs?.Select(isbn => new GetBookISBNDTO
            {
                BookISBNId = isbn.BookISBNId,
                ISBN = isbn.ISBN,
                PublishedYear = isbn.PublishedYear,
                Edition = isbn.Edition,

                Copies = isbn.BookCopies?.Select(copy => new GetBookCopyDTO
                {
                    BookCopyId = copy.BookCopyId,
                    CopyNumber = copy.CopyNumber,
                    BookStatusId = copy.BookStatusId,
                    BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
                }).ToList() ?? new List<GetBookCopyDTO>()
            }).ToList() ?? new List<GetBookISBNDTO>()

        }).ToList();
    }


    public List<GetBookISBNDTO> GetBookByISBNNumber(string number)
    {
        var bookList = bookISBNRepository.GetBookByISBNNumber(number);
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("Book Not Found");
        }
        return bookList.OrderBy(b => b.BookId).Select(book => new GetBookISBNDTO
        {

            BookISBNId = book.BookISBNId,
            ISBN = book.ISBN,
            PublishedYear = book.PublishedYear,
            Edition = book.Edition,

            Copies = book.BookCopies?.Select(copy => new GetBookCopyDTO
            {
                BookCopyId = copy.BookCopyId,
                CopyNumber = copy.CopyNumber,
                BookStatusId = copy.BookStatusId,
                BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
            }).ToList() ?? new List<GetBookCopyDTO>()
        }).ToList();
    }

    public GetBookCopyDTO? GetBookByCopyNumber(string CopyNumber)
    {
        var book = bookCopyRepository.GetBookByCopyNumber(CopyNumber);
        if (book == null)
        {
            return null;
        }
        return new GetBookCopyDTO
        {
            BookCopyId = book.BookCopyId,
            CopyNumber = book.CopyNumber,
            BookStatusId = book.BookStatusId,
            BookStatusName = book.BookStatus?.BookStatusName ?? string.Empty
        };
    }
    /*
    public List<BookCategory> GetBookByCategory(int id)
    {
        var booklist = bookCategoryRepository.GetBookByCategory(id);
        return booklist;
    }
    */

    public List<GetBookCopyDTO> GetBookByStatus(int id)
    {
        var booklist = bookCopyRepository.GetBookByStatus(id);
        return booklist.OrderBy(b=>b.BookCopyId).Select(book=> new GetBookCopyDTO
        {
            BookCopyId = book.BookCopyId,
            CopyNumber = book.CopyNumber,
            BookStatusId = book.BookStatusId,
            BookStatusName = book.BookStatus?.BookStatusName ?? string.Empty
        }).ToList();
    }

    public GetBookDTO? GetBookIdByTitle(string title)
    {
        var book = bookRepository.GetBookIdByTitle(title);
        if (book == null)
        {
            return null;
        }
        return new GetBookDTO
        {
            BookId = book.BookId,
            BookTitle = book.BookTitle,
            Author = book.Author,
            BookCategoryName = book?.BookCategory?.BookCategoryName ?? "",
            ISBNs = book?.BookISBNs?.Select(isbn => new GetBookISBNDTO
            {
                BookISBNId = isbn.BookISBNId,
                ISBN = isbn.ISBN,
                PublishedYear = isbn.PublishedYear,
                Edition = isbn.Edition,

                Copies = isbn.BookCopies?.Select(copy => new GetBookCopyDTO
                {
                    BookCopyId = copy.BookCopyId,
                    CopyNumber = copy.CopyNumber,
                    BookStatusId = copy.BookStatusId,
                    BookStatusName = copy.BookStatus?.BookStatusName ?? string.Empty
                }).ToList() ?? new List<GetBookCopyDTO>()
            }).ToList() ?? new List<GetBookISBNDTO>()
        };
    }

    public int GetNumberOfBookByCategory(int id)
    {
        return bookCategoryRepository.GetNumberOfBookByCategory(id);
    }
    public int GetNumberOfBookByBookTitle(string title)
    {
        var book = bookRepository.GetBookIdByTitle(title);
        if (book == null)
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