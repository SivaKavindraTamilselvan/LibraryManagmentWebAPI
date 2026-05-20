using LibraryManagement.ModelLibrary.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// all get borrowing services
public partial class AdminService
{
    public Borrowing? GetBorrowingById(int id)
    {
        var borrowing = borrowingRepository.Get(id);
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByMemberId(int id)
    {
        var borrowing = borrowingRepository.GetBorrowingByMemberId(id);
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByMemberEmail(string email)
    {
        var borrowing = borrowingRepository.GetBorrowingByMemberEmail(email);
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBorrowingStatus(int id)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingStatus(id);
        return borrowing;
    }
    public List<Borrowing> GetBorrowingByBorrowingDate(DateTime dateTime)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingBorrowdate(dateTime);
        return borrowing;
    }
    public List<Borrowing> GetBorrowingByDueDate(DateTime dateTime)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingDuedate(dateTime);
        return borrowing;
    }
    public List<Borrowing> GetBorrowingByReturnDate(DateTime dateTime)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingReturndate(dateTime);
        return borrowing;
    }

    public List<Borrowing> GetBorrowingTmrw()
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingDueByTommorrow();
        return borrowing;
    }

    public List<Borrowing> GetBorrowingByBookTitle(string title)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingByTitle(title);
        return borrowing;
    }
    public List<Borrowing> GetBorrowingByBookCopy(int id)
    {
        var borrowing = borrowingRepository.GetBorrowingByBorrowingByBookCopyId(id);
        return borrowing;
    }
}