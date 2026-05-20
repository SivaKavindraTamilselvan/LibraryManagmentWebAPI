using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// get member service
public partial class AdminService 
{
    public List<Member> GetAllMembers()
    {
        var memberList = memberRepository.GetAllMembers();
        return memberList;
    }
    public Member? GetMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        return member;
    }

    public Member? GetMemberByPhoneNumber(string email)
    {
        var member = memberRepository.GetMemberByPhoneNumber(email);
        return member;
    }
    public List<Member> GetMemberByRole(int RoleId)
    {
        var member = memberRepository.GetMemberByRole(RoleId);
        return member;
    }

    public Member? GetMemberById(int MemberId)
    {
        var member = memberRepository.Get(MemberId);
        return member;
    }
}