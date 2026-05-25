namespace LibraryManagement.DTOs;

public class GetBorrowingDTO
{
    public int BorrowingId {get;set;}
    public string MemberName {get;set;} = string.Empty;
    public string MemberEmail {get;set;} = string.Empty;
    public string BookCopyNumber {get;set;} = string.Empty;

    public DateTime BorrowedDate {get;set;}
    public DateTime DueDate {get;set;}
    public DateTime? ReturnDate {get;set;}
    public string BorrowingStatus {get;set;} = string.Empty;

    public DateTime createdAt {get;set;}
    public DateTime? updatedAt{get;set;}
}