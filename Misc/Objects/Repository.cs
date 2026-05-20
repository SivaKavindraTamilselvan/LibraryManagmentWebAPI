using LibraryManagement.Repositories;

namespace LibraryManagement.DataAccessLibrary.Object;

// created to avoid large number of parameters from one file to another
public class RepositoryManagment
{
    public MemberRepository memberRepository {get;set;}
    public BookRepository bookRepository {get;set;}
    public BookCategoryRepository bookCategoryRepository {get;set;}
    public BookISBNRepository bookISBNRepository {get;set;}
    public BookCopyRepository bookCopyRepository {get;set;}
    public BorrowingRepository borrowingRepository {get;set;}
    public DamagedBookRepository damagedBookRepository {get;set;}
    public FineRepository fineRepository {get;set;}
    public PaymentRepository paymentRepository {get;set;}
    public RepositoryManagment()
    {
        memberRepository = new MemberRepository();
        bookRepository = new BookRepository();
        bookCategoryRepository = new BookCategoryRepository();
        bookISBNRepository = new BookISBNRepository();
        bookCopyRepository = new BookCopyRepository();
        borrowingRepository = new BorrowingRepository();
        damagedBookRepository = new DamagedBookRepository();
        fineRepository = new FineRepository();
        paymentRepository = new PaymentRepository();
    }
}