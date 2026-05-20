using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class BorrowingService
{
    // add borrowing service
    
    public GetBorrowingDTO? AddBorrowing(CreateBorrowingDTO createBorrowingDTO)
    {
        Console.WriteLine("Enter The Member Id");
        int memberId = createBorrowingDTO.MemberId;

        int bookId = createBorrowingDTO.BookId;
        
        var book = bookRepository.Get(bookId);
        if(book == null)
        {
            throw new InvalidBookException("Book Not Found");
        }
        var borrowing = borrowingRepository.CreateBorrowing(memberId,book.BookId);
        if(borrowing == null)
        {
            return null;
        }
        borrowing = borrowingRepository.Get(borrowing.BorrowingId);
        if(borrowing == null)
        {
            return null;
        }
        return new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        };
    }
}