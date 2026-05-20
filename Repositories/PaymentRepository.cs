using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibraryManagement.Repositories;

// member repo for getting the details based on the filters
// usage of procedure and linq

public class PaymentRepository : AbstractRepository<int, Payment>
{
    public override Payment? Get(int key)
    {
        var payment = libraryManagementContext.Payment.Include(mp => mp.ModeOfPayment).Where(b => b.PaymentId == key).FirstOrDefault();
        return null;
    }

    public Payment? CreatePayment(Payment payment)
    {
        using var context = new LibraryManagementContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            libraryManagementContext.Database.ExecuteSqlInterpolated($"CALL pay_fine({payment.FineId},{payment.AmountPaid},{payment.ModeOfPaymentId})");
            transaction.Commit();
            libraryManagementContext.ChangeTracker.Clear();
            var paidPayment = libraryManagementContext.Payment.AsNoTracking().OrderByDescending(p => p.PaymentDate).FirstOrDefault(p => p.FineId == payment.FineId);
            return paidPayment;
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public List<Payment> GetPaymentsById(int id)
    {
        var payments = libraryManagementContext.Payment.Include(mp => mp.ModeOfPayment).Include(f => f.Fine).ThenInclude(br => br!.Borrowing).Where(m => m.Fine!.Borrowing!.MemberId == id).ToList();
        return payments;
    }

    public List<Payment> GetAllPayments()
    {
        var payments = libraryManagementContext.Payment.Include(mp => mp.ModeOfPayment).Include(f => f.Fine).ThenInclude(br => br!.Borrowing).ToList();
        return payments;
    }
}