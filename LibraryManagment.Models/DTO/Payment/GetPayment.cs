namespace LibraryManagement.DTOs;

public class GetPaymentDTO
{
    public int PaymentId { get; set; }
    public int FineId { get; set; }
    public string FineCategory { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public string ModeOfPayment { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public DateTime createdAt { get; set; }
}