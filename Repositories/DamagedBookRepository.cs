using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

// damagedbook repo for getting the details based on the filters
// usage of linq

public class DamagedBookRepository : AbstractRepository<int, DamagedBook>
{
    public override DamagedBook? Get(int key)
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).Where(b => b.DamagedBookId == key).FirstOrDefault();
        return null;
    }
    public List<DamagedBook> GetAllDamagedBook()
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).ToList();
        return book;
    }
}