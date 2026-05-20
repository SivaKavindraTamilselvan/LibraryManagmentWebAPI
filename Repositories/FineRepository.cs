using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

// fine repo for getting the details based on the filters
// usage of linq

public class FineRepository : AbstractRepository<int, Fine>,IFineRepository
{
    public FineRepository(LibraryManagementContext libraryManagementContext) : base(libraryManagementContext)
    {
        
    }
    public override Fine? Get(int key)
    {
        var fine = libraryManagementContext.Fine.Where(b => b.FineId == key).FirstOrDefault();
        return null;
    }

    public List<Fine> GetReportOfMemberWithPendingFine()
    {
        var memberList = libraryManagementContext.Fine.Include(fc=>fc.FineCategory).Include(b=>b.Borrowing).ThenInclude(bc=>bc!.BookCopy).ThenInclude(bi=>bi!.BookISBN).ThenInclude(b=>b!.Book).Include(b=>b.Borrowing).ThenInclude(m=>m!.Member).ThenInclude(mt=>mt!.MemberType).Where(b=>b.IsPaidFully == false).ToList();
        return memberList;
    }

    public List<Fine> GetReportOfMemberWithPendingFine(int id)
    {
        var memberList = libraryManagementContext.Fine.Include(fc=>fc.FineCategory).Include(b=>b.Borrowing).ThenInclude(bc=>bc!.BookCopy).ThenInclude(bi=>bi!.BookISBN).ThenInclude(b=>b!.Book).Include(b=>b.Borrowing).ThenInclude(m=>m!.Member).ThenInclude(mt=>mt!.MemberType).Where(b=>b.IsPaidFully == false).Where(b=>b!.Borrowing!.Member!.MemberId == id).ToList();
        return memberList;
    }
}