namespace LibraryManagement.DTOs;

public class CreateBorrowingDTO
{
    public int MemberId {get;set;}
    public int BookId {get;set;}
    public int BorrowingStatusId {get;set;}
}