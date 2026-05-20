using LibraryManagement.Interfaces;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// decativate the member
// if member already deactivated exception is raised
public partial class AdminService 
{
    public Member? DeactivateTheMemberByMemberId(int id)
    {
        var updatedMember = memberRepository.DeactivateMember(id);
        return updatedMember;
    }
    public Member? DeactivateTheMemberByEmail(string email)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
        return updatedMember;
    }
    public Member? DeactivateTheMemberByPhoneNumber(string PhoneNumber)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException("Member Id Not Found");
        }
        var updatedMember = memberRepository.DeactivateMember(member.MemberId);
        return updatedMember;
    }
}
