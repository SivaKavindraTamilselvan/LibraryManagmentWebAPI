using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// report services to get all the needed information
public partial class AdminService
{
    public List<Borrowing> GetReportOfOverDueBook()
    {
        var borrowing = borrowingRepository.GetOverDueBooks();
        return borrowing;
    }
    public List<Fine> GetMemberWithPendingFine()
    {
        var fines = fineRepository.GetReportOfMemberWithPendingFine();
        return fines;
    }

    public List<Fine> GetMemberWithPendingFine(int id)
    {
        var fines = fineRepository.GetReportOfMemberWithPendingFine(id);
        return fines;
    }

    public Book? GetReportOfBookHistory(int id)
    {
        var bookList = bookRepository.GetBooksReport(id);
        return bookList;
    }
    public List<Payment> GetReportOfPaymentHistory()
    {
        var payments = paymentRepository.GetAll();
        return payments;
    }

    public List<DamagedBook> GetReportOfDamagedBook()
    {
        var damagedBooks = damagedBookRepository.GetAll();
        return damagedBooks;
    }

}