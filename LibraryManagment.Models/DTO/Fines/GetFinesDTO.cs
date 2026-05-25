namespace LibraryManagement.DTOs;

public class GetFineDTO
{
    public int FineId {get;set;}
    public int BorrowingId {get;set;}
    public int FineCategoryId {get;set;}
    public int? DamagedBookId {get;set;}
    public decimal FineAmount {get;set;}
    public bool IsPaidFully {get;set;} = false;
    public DateTime createdAt {get;set;}
    public DateTime? updatedAt {get;set;}
}