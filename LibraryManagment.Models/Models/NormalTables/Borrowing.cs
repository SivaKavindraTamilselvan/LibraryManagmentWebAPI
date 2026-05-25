namespace LibraryManagement.Models;

public class Borrowing
{
    public int BorrowingId {get;set;}
    public int MemberId {get;set;}
    public Member? Member {get;set;}
    public int BookCopyId {get;set;}
    public BookCopy? BookCopy {get;set;}

    public DateTime BorrowedDate {get;set;}
    public DateTime DueDate {get;set;}
    public DateTime? ReturnDate {get;set;}
    public int BorrowingStatusId {get;set;}
    public BorrowingStatus? BorrowingStatus {get;set;}

    public DateTime createdAt {get;set;}
    public DateTime? updatedAt{get;set;}
    public ICollection<Fine> Fines {get;set;} = new List<Fine>();

    public override string ToString()
    {
        string basic = "--------- BorrowingDetails ---------";
        return basic +"\n\n" + $"BorrowingId : {BorrowingId}\nMemberId : {MemberId}\nMemberEmail : {Member?.Email}\nBookCopyID : {BookCopyId}\nBookCopyNumber : {BookCopy?.CopyNumber}\nBorrowedDate : {BorrowedDate}\nDueDate : {DueDate}\nReturnDate : {ReturnDate}";
    }
    public string GetBorrowingByBook()
    {
        string basic = "--------- BorrowingDetails ---------";
        basic = basic + "\n\n" + $"BorrowingId : {BorrowingId}\nMemberId : {MemberId}\nMemberName : {Member?.FirstName + Member?.LastName}\nMemberEmail : {Member?.Email}\nMemberPhone : {Member?.PhoneNumber}\nMemberRole : {Member?.Role?.RoleName}\nMemberType : {Member?.MemberType?.MemberTypeName}\n";
        basic = basic + "\n\n" + $"BookCopyId : {BookCopyId}\nBookCopyNumber : {BookCopy?.CopyNumber}\nBookTitle : {BookCopy?.BookISBN?.Book?.BookTitle}\nBook Author : {BookCopy?.BookISBN?.Book?.Author}\nBookCategoryName : {BookCopy?.BookISBN?.Book?.BookCategory?.BookCategoryName}\n";
        basic = basic + "\n\n" + $"BookISBNId : {BookCopy?.BookISBN?.BookISBNId}\nBookISBNNumber : {BookCopy?.BookISBN?.ISBN}\nBookPublishedYear : {BookCopy?.BookISBN?.PublishedYear}\nBookEdition : {BookCopy?.BookISBN?.Edition}\n";
        basic = basic + "\n\n" + $"BorrowedDate : {BorrowedDate}\nDueDate : {DueDate}\nReturnDate : {ReturnDate}";
        return basic;
    }
}