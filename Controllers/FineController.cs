using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using LibraryManagement.Interfaces;
using LibraryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FineController : ControllerBase
{
    protected readonly FineService fineService;
    public FineController(FineService fineService)
    {
        this.fineService = fineService;
    }

    [HttpGet("GetAll")]
    public ActionResult<GetPaymentDTO> GetAll()
    {
        try
        {
            var result = fineService.GetAllFines();
            if(result == null)
            {
                throw new InvalidBorrowingException("Payment Not Done");
            }
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}