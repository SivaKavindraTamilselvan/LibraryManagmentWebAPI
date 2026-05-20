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
    protected readonly PaymentService paymentService;
    public PaymentController(PaymentService paymentService)
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
    public ActionResult<GetPaymentDTO> GetAll()
    {
        try
        {
            var result = paymentService.GetAllPayments();
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