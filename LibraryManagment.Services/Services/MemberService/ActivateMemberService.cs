using LibraryManagement.Exceptions;
using LibraryManagement.DTOs;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// activate the deactive member
// a member already then exception is raised
public partial class MemberService
{
    public GetMemberDTO? ActivateTheMemberByMemberId(int id)
    {
        var member = memberRepository.Get(id);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.isActive)
        {
            throw new InvalidMemberException("Already The Member Is activated");
        }
        member.isActive = true;
        member.updatedAt = DateTime.Now;
        var updatedMember = memberRepository.Update(id, member);
        if (updatedMember == null)
        {
            return null;
        }
        updatedMember = memberRepository.Get(updatedMember.MemberId);
        if (updatedMember == null)
        {
            return null;
        }
        return new GetMemberDTO
        {
            MemberId = updatedMember.MemberId,
            FirstName = updatedMember.FirstName,
            LastName = updatedMember.LastName,
            Email = updatedMember.Email,
            PhoneNumber = updatedMember.PhoneNumber,
            isActive = updatedMember.isActive,
            Role = updatedMember.Role?.RoleName ?? string.Empty,
            MemberType = updatedMember.MemberType?.MemberTypeName ?? string.Empty,
            createdAt = updatedMember.createdAt,
            updatedAt = updatedMember.updatedAt
        };
    }
    public GetMemberDTO? ActivateTheMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.isActive)
        {
            throw new InvalidMemberException("Already The Member Is activated");
        }
        member.isActive = true;
        member.updatedAt = DateTime.Now;
        var updatedMember = memberRepository.Update(member.MemberId, member);
        if (updatedMember == null)
        {
            return null;
        }
        updatedMember = memberRepository.Get(updatedMember.MemberId);
        if (updatedMember == null)
        {
            return null;
        }
        return new GetMemberDTO
        {
            MemberId = updatedMember.MemberId,
            FirstName = updatedMember.FirstName,
            LastName = updatedMember.LastName,
            Email = updatedMember.Email,
            PhoneNumber = updatedMember.PhoneNumber,
            isActive = updatedMember.isActive,
            Role = updatedMember.Role?.RoleName ?? string.Empty,
            MemberType = updatedMember.MemberType?.MemberTypeName ?? string.Empty,
            createdAt = updatedMember.createdAt,
            updatedAt = updatedMember.updatedAt
        };
    }
    public GetMemberDTO? ActivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.isActive)
        {
            throw new InvalidMemberException("Already The Member Is activated");
        }
        member.isActive = true;
        member.updatedAt = DateTime.Now;
        var updatedMember = memberRepository.Update(member.MemberId, member);
        if (updatedMember == null)
        {
            return null;
        }
        updatedMember = memberRepository.Get(updatedMember.MemberId);
        if (updatedMember == null)
        {
            return null;
        }
        return new GetMemberDTO
        {
            MemberId = updatedMember.MemberId,
            FirstName = updatedMember.FirstName,
            LastName = updatedMember.LastName,
            Email = updatedMember.Email,
            PhoneNumber = updatedMember.PhoneNumber,
            isActive = updatedMember.isActive,
            Role = updatedMember.Role?.RoleName ?? string.Empty,
            MemberType = updatedMember.MemberType?.MemberTypeName ?? string.Empty,
            createdAt = updatedMember.createdAt,
            updatedAt = updatedMember.updatedAt
        };
    }
}
