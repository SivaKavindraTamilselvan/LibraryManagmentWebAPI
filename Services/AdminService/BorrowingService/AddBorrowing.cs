using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class AdminService
{
    // add borrowing service
    /*
    public Borrowing? AddBorrowing()
    {
        Console.WriteLine("\n\n================ Enter The Details To Borrow The Book =================\n\n");
        Console.WriteLine("Enter The Member Id");
        int memberId = inputsCheck.IdInputs();
        Console.WriteLine("Enter The Book Title To Borrow");
        string title = Console.ReadLine() ?? "";
        
        var book = GetBookIdByTitle(title);
        // book by the title
        if(book == null)
        {
            throw new InvalidBookException("Book Not Found");
        }
        var borrowing = borrowingRepository.CreateBorrowing(memberId,book.BookId);
        if(borrowing == null)
        {
            return null;
        }
        return borrowing;
    }
    */
}