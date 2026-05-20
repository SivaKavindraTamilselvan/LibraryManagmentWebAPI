using LibraryManagement.DTOs;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// all get borrowing services
public partial class BorrowingService
{
    public GetBorrowingDTO? GetBorrowingById(int id)
    {
        var borrowing = borrowingRepository.Get(id);
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

    public List<GetBorrowingDTO> GetBorrowingByMemberId(int id)
    {
        var borrowings = borrowingRepository.GetBorrowingByMemberId(id);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }

    public List<GetBorrowingDTO> GetBorrowingByMemberEmail(string email)
    {
        var borrowings = borrowingRepository.GetBorrowingByMemberEmail(email);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }

    public List<GetBorrowingDTO> GetBorrowingByBorrowingStatus(int id)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingStatus(id);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }
    public List<GetBorrowingDTO> GetBorrowingByBorrowingDate(DateTime dateTime)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingBorrowdate(dateTime);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }
    public List<GetBorrowingDTO> GetBorrowingByDueDate(DateTime dateTime)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingDuedate(dateTime);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }
    public List<GetBorrowingDTO> GetBorrowingByReturnDate(DateTime dateTime)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingReturndate(dateTime);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }

    public List<GetBorrowingDTO> GetBorrowingTmrw()
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingDueByTommorrow();
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }

    public List<GetBorrowingDTO> GetBorrowingByBookTitle(string title)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingByTitle(title);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }
    public List<GetBorrowingDTO> GetBorrowingByBookCopy(int id)
    {
        var borrowings = borrowingRepository.GetBorrowingByBorrowingByBookCopyId(id);
        return borrowings.OrderBy(br=>br.BorrowingId).Select(borrowing => new GetBorrowingDTO
        {
            BorrowingId = borrowing.BorrowingId,
            MemberName = borrowing.Member?.FirstName?? "" + borrowing.Member?.LastName?? "",
            MemberEmail = borrowing.Member?.Email ?? "",
            BookCopyNumber = borrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = borrowing.BorrowedDate,
            DueDate = borrowing.DueDate,
            ReturnDate = borrowing.ReturnDate,
            BorrowingStatus = borrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        }).ToList();
    }
}