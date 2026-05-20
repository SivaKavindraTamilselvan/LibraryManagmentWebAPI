using LibraryManagement.Interfaces;
using LibraryManagement.UniqueNumbers;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class BookService : IBookService
{
    protected readonly IBookRepository bookRepository;
    protected readonly IBookISBNRepository bookISBNRepository;
    protected readonly IBookCopyRepository bookCopyRepository;
    protected readonly IBookCategoryRepository bookCategoryRepository;
    protected readonly GenerateUnique generateUnique;
    public BookService(IBookRepository bookRepository,IBookISBNRepository bookISBNRepository,IBookCopyRepository bookCopyRepository,IBookCategoryRepository bookCategoryRepository,GenerateUnique generateUnique)
    {
        this.bookRepository = bookRepository;
        this.bookISBNRepository = bookISBNRepository;
        this.bookCopyRepository = bookCopyRepository;
        this.bookCategoryRepository = bookCategoryRepository;
        this.generateUnique = generateUnique;
    }
}