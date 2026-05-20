using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.UniqueNumbers;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Interfaces;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// recieve every repo in the constructore
// to avoid duplicate object creation
public partial class AdminService
{
    protected readonly IMemberRepository memberRepository;
    protected readonly IBookRepository bookRepository;
    protected readonly IBookISBNRepository bookISBNRepository;
    protected readonly IBookCategoryRepository bookCategoryRepository;
    protected readonly IBookCopyRepository bookCopyRepository;
    protected readonly IBorrowingRepository borrowingRepository;
    protected readonly IDamagedRepository damagedBookRepository;
    protected readonly IFineRepository fineRepository;
    protected readonly IPaymentRepository paymentRepository;

    protected readonly GenerateUnique generateUnique;
    protected readonly InputsCheck inputsCheck;

    public AdminService(
    IMemberRepository memberRepository,
    IBookRepository bookRepository,
    IBookCategoryRepository bookCategoryRepository,
    IBookISBNRepository bookISBNRepository,
    IBookCopyRepository bookCopyRepository,
    IBorrowingRepository borrowingRepository,
    IDamagedRepository damagedBookRepository,
    IFineRepository fineRepository,
    IPaymentRepository paymentRepository,
    GenerateUnique generateUnique)
    {
        this.memberRepository = memberRepository;
        this.bookRepository = bookRepository;
        this.bookCategoryRepository = bookCategoryRepository;
        this.bookISBNRepository = bookISBNRepository;
        this.bookCopyRepository = bookCopyRepository;
        this.borrowingRepository = borrowingRepository;
        this.damagedBookRepository = damagedBookRepository;
        this.fineRepository = fineRepository;
        this.paymentRepository = paymentRepository;

        this.generateUnique = generateUnique;
        this.inputsCheck = new InputsCheck();
    }
}