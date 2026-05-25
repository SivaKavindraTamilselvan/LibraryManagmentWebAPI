using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;
public interface IFineRepository : IRepository<int,Fine>
{
    public List<Fine> GetReportOfMemberWithPendingFine();
    public List<Fine> GetReportOfMemberWithPendingFine(int id);
}