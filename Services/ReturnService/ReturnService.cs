using LibraryManagement.DTOs;
using LibraryManagement.Interfaces;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// return logic is added
// check the status of book 
// based on status fines will alos be added automaticlly
public class ReturnService
{
    protected readonly IBorrowingRepository borrowingRepository;
    public ReturnService(IBorrowingRepository borrowingRepository)
    {
        this.borrowingRepository = borrowingRepository;
    }
    public GetBorrowingDTO? AddReturn(CreateReturningDTO createReturningDTO)
    {
        int borrowId = createReturningDTO.BorrowingId;
        int bookStatus = createReturningDTO.BookStatusId;
        int damagedLevel = 0;
        if(bookStatus == 4)
        {
            damagedLevel = createReturningDTO.DamagedLevel;
        }
        bool lost = bookStatus == 3? true : false;
        //every validation are done here
        var updatedborrowing = borrowingRepository.ReturnBorrowing(borrowId,lost,damagedLevel);
        if(updatedborrowing == null)
        {
            return null;
        }
        updatedborrowing = borrowingRepository.Get(updatedborrowing.BorrowingId);
        if(updatedborrowing == null)
        {
            return null;
        }
        return new GetBorrowingDTO
        {
            BorrowingId = updatedborrowing.BorrowingId,
            MemberName = updatedborrowing.Member?.FirstName?? "" + updatedborrowing.Member?.LastName?? "",
            MemberEmail = updatedborrowing.Member?.Email ?? "",
            BookCopyNumber = updatedborrowing.BookCopy?.CopyNumber ?? "",
            BorrowedDate = updatedborrowing.BorrowedDate,
            DueDate = updatedborrowing.DueDate,
            ReturnDate = updatedborrowing.ReturnDate,
            BorrowingStatus = updatedborrowing.BorrowingStatus?.BorrowingStatusName ?? "",
        };
    }

    public List<GetBorrowingDTO> PendingReturn()
    {
        var borrowings = borrowingRepository.GetPendingReturn();
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