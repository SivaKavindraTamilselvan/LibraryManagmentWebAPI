using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    protected readonly BookService bookService;
    public BookController(BookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet("GetAllBooks")]
    public ActionResult<List<GetBookDTO>> GetAllBooks()
    {
        try
        {
            var result = bookService.GetAllBooks();
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public ActionResult<GetBookDTO> GetBookByBookId(int id)
    {
        try
        {
            var result = bookService.GetBookByBookId(id);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBooksByTitle")]
    public ActionResult<List<GetBookDTO>> GetBookByBookTitle(string Title)
    {
        try
        {
            var result = bookService.GetBookByBookTitle(Title);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBooksByAuthor")]
    public ActionResult<List<GetBookDTO>> GetBookByBookAuthor(string author)
    {
        try
        {
            var result = bookService.GetBookByBookAuthor(author);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBooksByISBNNumber")]
    public ActionResult<List<GetBookISBNDTO>> GetBookByISBNNumber(string number)
    {
        try
        {
            var result = bookService.GetBookByISBNNumber(number);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBooksByCopyNumber")]
    public ActionResult<GetBookCopyDTO> GetBookByCopyNumber(string CopyNumber)
    {
        try
        {
            var result = bookService.GetBookByCopyNumber(CopyNumber);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetBooksByStatusId")]
    public ActionResult<List<GetBookCopyDTO>> GetBookByStatus(int id)
    {
        try
        {
            var result = bookService.GetBookByStatus(id);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Book")]
    public ActionResult<List<GetBookCopyDTO>> CreateBook(CreateBookDTO createBookDTO)
    {
        try
        {
            var result = bookService.AddBook(createBookDTO);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("BookISBN")]
    public ActionResult<List<GetBookCopyDTO>> CreateBookISBN(CreateBookISBNDTO createBookISBNDTO)
    {
        try
        {
            var result = bookService.AddBookISBN(createBookISBNDTO);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("BookCopy")]
    public ActionResult<List<GetBookCopyDTO>> CreateBookCopy(CreateBookCopyDTO createBookCopyDTO)
    {
        try
        {
            var result = bookService.AddBookCopy(createBookCopyDTO);
            if (result == null)
            {
                throw new InvalidBookException("Book Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}