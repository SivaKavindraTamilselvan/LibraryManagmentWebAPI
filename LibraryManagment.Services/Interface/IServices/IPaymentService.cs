using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IPaymentService
{
    public GetPaymentDTO? AddPayment(CreatePaymentDTO createPaymentDTO);
    public List<GetPaymentDTO> GetAllPayments();
}