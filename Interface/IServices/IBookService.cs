using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IBookService
{
    public GetSimpleBookDTO? AddBook(CreateBookDTO createBookDTO);
    public GetSimpleBookISBNDTO? AddBookISBN(CreateBookISBNDTO createBookISBNDTO);
    public GetBookCopyDTO? AddBookCopy(CreateBookCopyDTO createBookCopyDTO);
    public List<GetBookDTO> GetAllBooks();
    public GetBookDTO? GetBookByBookId(int id);
    public List<GetBookDTO> GetBookByBookTitle(string Title);
    public List<GetBookDTO> GetBookByBookAuthor(string author);
    public List<GetBookISBNDTO> GetBookByISBNNumber(string number);
    public GetBookCopyDTO? GetBookByCopyNumber(string CopyNumber);
    public List<GetBookCopyDTO> GetBookByStatus(int id);
    public GetBookDTO? GetBookIdByTitle(string title);
    public int GetNumberOfBookByCategory(int id);
    public int GetNumberOfBookByBookTitle(string title);
    public int GetNumberOfBookByISBN(string isbn);
}