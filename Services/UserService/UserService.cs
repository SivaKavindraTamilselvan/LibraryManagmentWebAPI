using LibraryManagement.DataAccessLibrary.Object;
using LibraryManagement.UniqueNumbers;
using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// user services
// only to view the details
// the adding, fine collection everything will be done by admin
// to avoid unwanted fine entry
public partial class UserService
{
    protected readonly MemberRepository memberRepository;
    protected readonly BookRepository bookRepository;
    protected readonly BookISBNRepository bookISBNRepository;
    protected readonly BookCategoryRepository bookCategoryRepository;
    protected readonly BookCopyRepository bookCopyRepository;
    protected readonly BorrowingRepository borrowingRepository;
    protected readonly GenerateUnique generateUnique;
    protected readonly DamagedBookRepository damagedBookRepository;
    protected readonly FineRepository fineRepository;
    protected readonly PaymentRepository paymentRepository;


    public UserService(RepositoryManagment repositoryManagment)
    {
        memberRepository = repositoryManagment.memberRepository;
        bookRepository = repositoryManagment.bookRepository;
        bookCategoryRepository = repositoryManagment.bookCategoryRepository;
        bookISBNRepository = repositoryManagment.bookISBNRepository;
        bookCopyRepository = repositoryManagment.bookCopyRepository;
        borrowingRepository = repositoryManagment.borrowingRepository;
        damagedBookRepository = repositoryManagment.damagedBookRepository;
        fineRepository = repositoryManagment.fineRepository;
        paymentRepository = repositoryManagment.paymentRepository;
        generateUnique = new GenerateUnique();
    }

    public List<Borrowing> GetBooksBorrowed(string email)
    {
        var borrowing = borrowingRepository.GetBorrowingByMemberEmail(email).Where(b => b.BorrowingStatusId == 1).ToList();
        return borrowing;
    }
    public List<Borrowing> GetBooksReturned(string email)
    {
        var borrowing = borrowingRepository.GetBorrowingByMemberEmail(email).Where(b => b.BorrowingStatusId == 2).ToList();
        return borrowing;
    }

    public List<Borrowing> GetBooksOverDue(string email)
    {
        var borrowing = borrowingRepository.GetBorrowingByMemberEmail(email).Where(b => b.ReturnDate == null && b.DueDate < DateTime.Now.Date).ToList();
        return borrowing;
    }
    public List<Fine> GetFinePending(int id)
    {
        var fines = fineRepository.GetReportOfMemberWithPendingFine(id);
        return fines;
    }

     public List<Payment> GetPayments(int id)
    {
        var payments = paymentRepository.GetPaymentsById(id);
        return payments;
    }

}