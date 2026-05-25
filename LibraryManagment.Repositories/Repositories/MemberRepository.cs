
using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibraryManagement.Repositories;

// memebr repo for getting the details based on the filters
// usage of procedure and linq

public class MemberRepository : AbstractRepository<int, Member>,IMemberRepository
{
    public MemberRepository(LibraryManagementContext libraryManagementContext) : base(libraryManagementContext)
    {
        
    }
    public override Member? Get(int MemberId)
    {
        var member = libraryManagementContext.Member.Include(r => r.Role).Include(mt => mt.MemberType).Where(m => m.MemberId == MemberId).FirstOrDefault();
        return member;
    }

    public override List<Member> GetAll()
    {
        var member = libraryManagementContext.Member.Include(r => r.Role).Include(mt => mt.MemberType).ToList();
        return member;
    }
    public Member? GetMemberByEmail(string email)
    {
        var member = libraryManagementContext.Member.Include(r => r.Role).Include(mt => mt.MemberType).Where(m => m.Email == email).FirstOrDefault();
        return member;
    }
    public Member? GetMemberByPhoneNumber(string PhoneNumber)
    {
        var member = libraryManagementContext.Member.Include(r => r.Role).Include(mt => mt.MemberType).Where(m => m.PhoneNumber == PhoneNumber).FirstOrDefault();
        return member;
    }

    public List<Member> GetMemberByRole(int RoleId)
    {
        var member = libraryManagementContext.Member.Include(r => r.Role).Include(mt => mt.MemberType).Where(m => m.RoleId == RoleId).ToList();
        return member;
    }

    public Member? DeactivateMember(int memberId)
    {

        try
        {
            libraryManagementContext.Database.ExecuteSqlInterpolated($"CALL deactivate_member({memberId})");
            libraryManagementContext.ChangeTracker.Clear();

            var member = libraryManagementContext.Member.AsNoTracking().Where(b => b.MemberId == memberId).FirstOrDefault();
            return member;
        }
        catch (PostgresException ex)
        {
            throw new DatabaseOperationException(ex.MessageText);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        return null;
    }
}
