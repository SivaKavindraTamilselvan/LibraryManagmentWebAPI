using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;
public interface IPaymentRepository : IRepository<int,Payment>
{
    public List<Payment> GetPaymentsById(int id);
}