using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.DataAccessLibrary.Object;
using LibraryManagement.UniqueNumbers;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// recieve every repo in the constructore
// to avoid duplicate object creation
public partial class AdminService
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


    public AdminService(RepositoryManagment repositoryManagment)
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
    InputsCheck inputsCheck = new InputsCheck();
}
