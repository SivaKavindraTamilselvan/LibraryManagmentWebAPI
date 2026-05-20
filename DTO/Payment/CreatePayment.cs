namespace LibraryManagement.DTOs;

public class CreatePaymentDTO
{
    public int FineId {get;set;}
    public decimal AmountPaid {get;set;}
    public int ModeOfPaymentId {get;set;}
}