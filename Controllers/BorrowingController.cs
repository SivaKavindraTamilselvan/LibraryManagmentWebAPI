using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowingController : ControllerBase
{
    protected readonly BorrowingService borrowingService;
    protected readonly ReturnService returnService;
    public BorrowingController(BorrowingService borrowingService, ReturnService returnService)
    {
        this.borrowingService = borrowingService;
        this.returnService = returnService;
    }

    [HttpGet]
    public ActionResult<GetBorrowingDTO> GetBorrowingById(int id)
    {
        try
        {
            var result = borrowingService.GetBorrowingById(id);
            if (result == null)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByMemberId")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByMemberId(int id)
    {
        try
        {
            var result = borrowingService.GetBorrowingByMemberId(id);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByMemberEmail")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByMemberEmail(string email)
    {
        try
        {
            var result = borrowingService.GetBorrowingByMemberEmail(email);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByBorrowingStatus")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByBorrowingStatus(int id)
    {
        try
        {
            var result = borrowingService.GetBorrowingByBorrowingStatus(id);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByBorrowingDate")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByBorrowingDate(DateTime dateTime)
    {
        try
        {
            var result = borrowingService.GetBorrowingByBorrowingDate(dateTime);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByDueDate")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByDueDate(DateTime dateTime)
    {
        try
        {
            var result = borrowingService.GetBorrowingByDueDate(dateTime);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByReturnDate")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByReturnDate(DateTime dateTime)
    {
        try
        {
            var result = borrowingService.GetBorrowingByReturnDate(dateTime);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByTomorrow")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByTmrw()
    {
        try
        {
            var result = borrowingService.GetBorrowingTmrw();
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByBookTitle")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByBookTitle(string title)
    {
        try
        {
            var result = borrowingService.GetBorrowingByBookTitle(title);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetBorrowingByBookCopyId")]
    public ActionResult<List<GetBorrowingDTO>> GetBorrowingByBookCopy(int id)
    {
        try
        {
            var result = borrowingService.GetBorrowingByBookCopy(id);
            if (result.Count == 0)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<GetBorrowingDTO> AddBorrowing(CreateBorrowingDTO createBorrowingDTO)
    {
        try
        {
            var result = borrowingService.AddBorrowing(createBorrowingDTO);
            if (result == null)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult<GetBorrowingDTO> AddReturn(CreateReturningDTO createReturningDTO)
    {
        try
        {
            var result = returnService.AddReturn(createReturningDTO);
            if (result == null)
            {
                throw new InvalidBorrowingException("Borrowing Not Done");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}