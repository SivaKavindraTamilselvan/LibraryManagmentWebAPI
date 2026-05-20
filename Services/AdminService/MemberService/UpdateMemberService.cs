using LibraryManagement.Interfaces;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.DTOs;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// update the member tyoe service
public partial class AdminService
{
    public GetMemberDTO? UpdateTheMemberTypeByMemberId(int id, int MemberTypeId)
    {
        var member = memberRepository.Get(id);
        if (member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if (member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
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
    public GetMemberDTO? UpdateTheMemberTypeByEmail(string email, int MemberTypeId)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if (member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if (member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
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
    public GetMemberDTO? UpdateTheMemberTypeByPhoneNumber(string PhoneNumber, int MemberTypeId)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if (member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if (member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
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
