using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// get member service
public partial class MemberService
{
    public List<GetMemberDTO> GetAllMembers()
    {
        var memberList = memberRepository.GetAll();
        if (memberList.Count == 0)
        {
            throw new InvalidMemberException("Member List Is Empty");
        }
        return memberList.OrderBy(m=>m.MemberId).Select(member => new GetMemberDTO
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
        }).ToList();
    }
    public GetMemberDTO? GetMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if (member == null)
        {
            return null;
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

    public GetMemberDTO? GetMemberByPhoneNumber(string email)
    {
        var member = memberRepository.GetMemberByPhoneNumber(email);
        if (member == null)
        {
            return null;
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
    public List<GetMemberDTO> GetMemberByRole(int RoleId)
    {
        var members = memberRepository.GetMemberByRole(RoleId);
        if (members.Count == 0)
        {
            throw new InvalidMemberException("Member List Is Empty");
        }
        return members.OrderBy(m=>m.MemberId).Select(member => new GetMemberDTO
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
        }).ToList();
    }

    public GetMemberDTO? GetMemberById(int MemberId)
    {
        var member = memberRepository.Get(MemberId);
        if (member == null)
        {
            return null;
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