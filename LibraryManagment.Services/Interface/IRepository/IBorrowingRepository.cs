using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;

public interface IBorrowingRepository : IRepository<int, Borrowing>
{
    public Borrowing? CreateBorrowing(int memberId, int bookId);
    public Borrowing? ReturnBorrowing(int borrowId, bool lost, int damagedLevel);
    public List<Borrowing> GetBorrowingByMemberId(int memberId);
    public List<Borrowing> GetBorrowingByMemberEmail(string email);
    public List<Borrowing> GetBorrowingByBorrowingStatus(int id);
    public List<Borrowing> GetBorrowingByBorrowingBorrowdate(DateTime dateTime);
    public List<Borrowing> GetBorrowingByBorrowingDuedate(DateTime dateTime);
    public List<Borrowing> GetBorrowingByBorrowingReturndate(DateTime dateTime);
    public List<Borrowing> GetBorrowingByBorrowingDueByTommorrow();
    public List<Borrowing> GetBorrowingByBorrowingByTitle(string title);
    public List<Borrowing> GetBorrowingByBorrowingByBookCopyId(int id);
    public List<Borrowing> GetPendingReturn();
    public List<Borrowing> GetOverDueBooks();
}