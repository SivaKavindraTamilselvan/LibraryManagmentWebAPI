using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

// damagedbook repo for getting the details based on the filters
// usage of linq

public class DamagedBookRepository : AbstractRepository<int, DamagedBook>,IDamagedRepository
{
    public DamagedBookRepository(LibraryManagementContext libraryManagementContext) : base(libraryManagementContext)
    {
        
    }
    public override DamagedBook? Get(int key)
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).Where(b => b.DamagedBookId == key).FirstOrDefault();
        return null;
    }
    public override List<DamagedBook> GetAll()
    {
        var book = libraryManagementContext.DamagedBook.Include(dl=>dl.DamagedLevel).ToList();
        return book;
    }
}