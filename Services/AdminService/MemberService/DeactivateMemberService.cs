using LibraryManagement.Interfaces;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryManagement.DTOs;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// decativate the member
// if member already deactivated exception is raised
public partial class AdminService
{
    public GetMemberDTO? DeactivateTheMemberByMemberId(int id)
    {
        var updatedMember = memberRepository.DeactivateMember(id);
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
    public GetMemberDTO? DeactivateTheMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if (member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
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
    public GetMemberDTO? DeactivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if (member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
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
