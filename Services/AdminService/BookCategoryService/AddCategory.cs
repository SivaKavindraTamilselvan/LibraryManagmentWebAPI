using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;
public partial class AdminService
{
    // to add the book category
    public BookCategory AddBookCategory()
    {
        BookCategory category = new BookCategory();
        Console.WriteLine("Enter The Book Category Name");
        string BookCategoryName = Console.ReadLine() ?? "";
        while (BookCategoryName.Trim() == "")
        {
            Console.WriteLine("Invalid Book CategoryName.Book Title Should Not be Empty.Enter Valid Name");
            BookCategoryName = Console.ReadLine() ?? "";
        }
        category.BookCategoryName = BookCategoryName;
        var createdBookCategory = bookCategoryRepository.Create(category);
        return createdBookCategory;
    }
}