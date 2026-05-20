using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// all get borrowing services
public partial class BorrowingService
{
    protected readonly IBorrowingRepository borrowingRepository;
    protected readonly IBookRepository bookRepository;
    public BorrowingService(IBorrowingRepository borrowingRepository,IBookRepository bookRepository)
    {
        this.borrowingRepository = borrowingRepository;
        this.bookRepository = bookRepository;
    }
}