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
    protected readonly IFineService fineService;
    public FineController(IFineService fineService)
    {
        this.fineService = fineService;
    }

    [HttpGet("GetAll")]
    public ActionResult<List<GetPaymentDTO>> GetAll()
    {
        try
        {
            var result = fineService.GetAllFines();
            if(result.Count == 0)
            {
                throw new InvalidBorrowingException("Fine Not Found");
            }
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}