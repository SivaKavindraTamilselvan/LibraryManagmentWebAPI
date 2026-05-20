using LibraryManagement.DTOs;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public class PaymentService : IPaymentService
{
    protected readonly IPaymentRepository paymentRepository;
    public PaymentService(IPaymentRepository paymentRepository)
    {
        this.paymentRepository = paymentRepository;
    }
    // add payments for the fines
    public GetPaymentDTO? AddPayment(CreatePaymentDTO createPaymentDTO)
    {
        Payment payment = new Payment();
        int fineId = createPaymentDTO.FineId;
        decimal amountPaid = createPaymentDTO.AmountPaid;
        int paymentId = createPaymentDTO.ModeOfPaymentId;

        payment.FineId = fineId;
        payment.AmountPaid = amountPaid;
        payment.ModeOfPaymentId = paymentId;
        var createdPayment = paymentRepository.Create(payment);
        createdPayment = paymentRepository.Get(payment.PaymentId);
        if(createdPayment == null)
        {
            return null;
        }
        return new GetPaymentDTO
        {
            PaymentId = createdPayment.PaymentId,
            FineId = createdPayment.FineId,
            FineCategory = createdPayment.Fine?.FineCategory?.FineCategoryName?? "",
            AmountPaid = createdPayment.AmountPaid,
            ModeOfPayment = createdPayment.ModeOfPayment?.ModeOfPaymentName ?? "",
            createdAt = createdPayment.createdAt,
            PaymentDate = createdPayment.PaymentDate,

        };
    } 
}