using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IBorrowingService
{
    public GetBorrowingDTO? GetBorrowingById(int id);
    public List<GetBorrowingDTO> GetBorrowingByMemberId(int id);
    public List<GetBorrowingDTO> GetBorrowingByMemberEmail(string email);
    public List<GetBorrowingDTO> GetBorrowingByBorrowingStatus(int id);
    public List<GetBorrowingDTO> GetBorrowingByBorrowingDate(DateTime dateTime);
    public List<GetBorrowingDTO> GetBorrowingByDueDate(DateTime dateTime);
    public List<GetBorrowingDTO> GetBorrowingByReturnDate(DateTime dateTime);
    public List<GetBorrowingDTO> GetBorrowingTmrw();
    public List<GetBorrowingDTO> GetBorrowingByBookTitle(string title);
    public List<GetBorrowingDTO> GetBorrowingByBookCopy(int id);
}