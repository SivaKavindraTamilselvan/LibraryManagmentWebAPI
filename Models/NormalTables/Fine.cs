namespace LibraryManagement.Models;
public class Fine
{
    public int FineId {get;set;}
    public int BorrowingId {get;set;}
    public Borrowing? Borrowing {get;set;}
    public int FineCategoryId {get;set;}
    public FineCategory? FineCategory {get;set;}
    public int? DamagedBookId {get;set;}
    public DamagedBook? DamagedBook {get;set;}
    public decimal FineAmount {get;set;}
    public bool IsPaidFully {get;set;} = false;
    public DateTime createdAt {get;set;}
    public DateTime? updatedAt {get;set;}
    public ICollection<Payment> Payments {get;set;} = new List<Payment>();
    public override string ToString()
    {
        return $"FineId : {FineId}\nBorrowingId : {BorrowingId}\nFineCategoryId : {FineCategoryId}\nFineAmount : {FineAmount}\nIsPaidFully :{IsPaidFully}";
    }
}