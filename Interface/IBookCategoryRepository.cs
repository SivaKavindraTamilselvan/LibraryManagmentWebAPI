using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;
public interface IBookCategoryRepository : IRepository<int,BookCategory>
{
    public List<BookCategory> GetBookByCategory(int id);
    public int GetNumberOfBookByCategory(int id);
}