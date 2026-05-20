using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using LibraryManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    protected readonly IPaymentService paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    [HttpPost]
    public ActionResult<GetPaymentDTO> AddPayment(CreatePaymentDTO createPaymentDTO)
    {
        try
        {
            var result = paymentService.AddPayment(createPaymentDTO);
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
    [HttpGet("GetAllPayments")]
    public ActionResult<List<GetPaymentDTO>> GetAll()
    {
        try
        {
            var result = paymentService.GetAllPayments();
            if(result.Count == 0)
            {
                throw new InvalidBorrowingException("Payment Not Found");
            }
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}