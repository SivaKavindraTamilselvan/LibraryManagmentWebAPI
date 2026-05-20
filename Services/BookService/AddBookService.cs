using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class BookService
{
    // add the basic book details into the book table
    public GetSimpleBookDTO? AddBook(CreateBookDTO createBookDTO)
    {
        Book book = new Book();
        string BookTitle = createBookDTO.BookTitle;
        // to check the book title not empty
        if (BookTitle.Trim() == "")
        {
            throw new InvalidBookException("Invalid Book Title.Book Title Should Not be Empty.Enter Valid Name");
        }
        // to check the book author not empty
        string Author = createBookDTO.Author;
        if (Author.Trim() == "")
        {
            throw new InvalidBookException("Invalid Book Title.Book Title Should Not be Empty.Enter Valid Name");
        }
        Console.WriteLine("\nEnter The Category Id");
        int categoryId = createBookDTO.BookCategoryId;
        var catgory = bookCategoryRepository.Get(categoryId);
        // through the exception if there is no category id like that in the table
        if (catgory == null)
        {
            throw new InvalidBookException("Book Category Is Not Found. So Book Not Added");
        }

        book.BookCategoryId = categoryId;
        book.Author = Author;
        book.BookTitle = BookTitle;
        //pass to repo to create the book
        var createdBook = bookRepository.Create(book);
        //if not created through exception
        if (createdBook == null)
        {
            throw new InvalidBookException("No Book Is Created");
        }
        createdBook = bookRepository.Get(createdBook.BookId);
        if (createdBook == null)
        {
            throw new InvalidBookException("No Book Is Created");
        }
        return new GetSimpleBookDTO
        {
            BookId = createdBook.BookId,
            BookTitle = createdBook.BookTitle,
            Author = createdBook.Author,
            BookCategoryName = createdBook.BookCategory?.BookCategoryName ?? ""
        };
    }

    // add book isbn details to the book created
    public GetSimpleBookISBNDTO? AddBookISBN(CreateBookISBNDTO createBookISBNDTO)
    {
        BookISBN bookISBN = new BookISBN();
        // check the inputs and validations
        int year = createBookISBNDTO.PublishedYear;
        int Edition = createBookISBNDTO.Edition; 
        if (Edition < 0)
        {
            throw new InvalidBookException("Enter The Valid Edition Number");
        }
        var bookList = bookRepository.GetAll();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Is Found In The Basic Book. Added That Initally");
        }
        Console.WriteLine("\nThis Is The List Of The Books That Can Be Added");
        int bookId = createBookISBNDTO.BookId;
        if (bookRepository.Get(bookId) == null)
        {
            throw new InvalidBookException("Book is Not Found In The List");
        }
        bookISBN.PublishedYear = year;
        bookISBN.Edition = Edition;
        bookISBN.BookId = bookId;
        // generate random unique ISBN Number by system itself
        bookISBN.ISBN = generateUnique.GenerateISBN();
        // pass to the repo to create the book
        var createdBookISBN = bookISBNRepository.Create(bookISBN);
        if(createdBookISBN == null)
        {
            throw new InvalidBookException("Book is Not Created");
        }
        createdBookISBN = bookISBNRepository.Get(createdBookISBN.BookISBNId);
        if(createdBookISBN == null)
        {
            throw new InvalidBookException("Book is Not Created");
        }
        return new GetSimpleBookISBNDTO
        {
            ISBN = createdBookISBN?.ISBN ?? "",
            BookISBNId = createdBookISBN.BookISBNId,
            PublishedYear = createdBookISBN.PublishedYear,
            Edition = createdBookISBN.Edition
        };
    }

    // add the book copies to the book isbn created
    public GetBookCopyDTO? AddBookCopy(CreateBookCopyDTO createBookCopyDTO)
    {
        BookCopy bookCopy = new BookCopy();
        var bookList = bookISBNRepository.GetAll();
        if (bookList.Count == 0)
        {
            throw new InvalidBookException("No Book Is Found In The Basic Book. Added That Initally");
        }
        int ISBN = createBookCopyDTO.BookISBNId;
        if (bookISBNRepository.Get(ISBN) == null)
        {
            throw new InvalidBookException("Book is Not Found In The List");
        }
        int bookStatusId = createBookCopyDTO.BookStatusId;
        bookCopy.CopyNumber = generateUnique.GenerateCopy();
        bookCopy.BookStatusId = bookStatusId;
        bookCopy.BookISBNId = ISBN;
        var createdBookCopy = bookCopyRepository.Create(bookCopy);
        createdBookCopy = bookCopyRepository.Get(bookCopy.BookCopyId);
        if (createdBookCopy == null)
        {
            return null;
        }
        return new GetBookCopyDTO
        {
            BookCopyId = createdBookCopy.BookCopyId,
            BookStatusId = createdBookCopy.BookStatusId,
            CopyNumber = createdBookCopy.CopyNumber,
            BookStatusName = createdBookCopy.BookStatus?.BookStatusName ?? ""
        };
    }
}