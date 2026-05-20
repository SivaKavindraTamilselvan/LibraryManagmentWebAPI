using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// get member service
public partial class AdminService
{
    public List<Member> GetAllMembers()
    {
        var memberList = memberRepository.GetAll();
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

    public GetMemberDTO? GetMemberById(int MemberId)
    {
        var member = memberRepository.Get(MemberId);
        if(member == null)
        {
            throw new InvalidMemberException("User Not Found");
        }
        return new GetMemberDTO
        {
            MemberId = member.MemberId,
            FirstName = member.FirstName,
            LastName = member.LastName,
            Email = member.Email,
            PhoneNumber = member.PhoneNumber,
            isActive = member.isActive,
            Role = member.Role?.RoleName ?? string.Empty,
            MemberType = member.MemberType?.MemberTypeName ?? string.Empty,
            createdAt = member.createdAt,
            updatedAt = member.updatedAt
        };
    }
}