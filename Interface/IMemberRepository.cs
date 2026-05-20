using LibraryManagement.Models;

namespace LibraryManagement.Interfaces;

public interface IMemberRepository : IRepository<int, Member>
{
    public Member? GetMemberByEmail(string email);
    public Member? GetMemberByPhoneNumber(string PhoneNumber);
    public List<Member> GetMemberByRole(int RoleId);
    public Member? DeactivateMember(int memberId);
}