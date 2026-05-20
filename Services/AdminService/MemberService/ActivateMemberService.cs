using LibraryManagement.Interfaces;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// activate the deactive member
// a member already then exception is raised
public partial class AdminService 
{
    public Member? ActivateTheMemberByMemberId(int id)
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
        var updatedMember = memberRepository.Update(id,member);
        return updatedMember;
    }
    public Member? ActivateTheMemberByEmail(string email)
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
        var updatedMember = memberRepository.Update(member.MemberId,member);
        return updatedMember;
    }
    public Member? ActivateTheMemberByPhoneNumber(string PhoneNumber)
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
        var updatedMember = memberRepository.Update(member.MemberId,member);
        return updatedMember;
    }
}
