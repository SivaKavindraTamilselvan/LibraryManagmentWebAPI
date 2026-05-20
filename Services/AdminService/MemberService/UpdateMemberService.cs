using LibraryManagement.Interfaces;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// update the member tyoe service
public partial class AdminService 
{
    public Member? UpdateTheMemberTypeByMemberId(int id,int MemberTypeId)
    {
        var member = memberRepository.Get(id);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
        var updatedMember = memberRepository.Update(id,member);
        return updatedMember;
    }
    public Member? UpdateTheMemberTypeByEmail(string email,int MemberTypeId)
    {
        var member = memberRepository.GetMemberByEmail(email);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
        var updatedMember = memberRepository.Update(member.MemberId,member);
        return updatedMember;
    }
    public Member? UpdateTheMemberTypeByPhoneNumber(string PhoneNumber,int MemberTypeId)
    {
        var member = memberRepository.GetMemberByPhoneNumber(PhoneNumber);
        if(member == null)
        {
            throw new InvalidMemberException("No user Found In With The Member Id");
        }
        if(member.MemberTypeId == MemberTypeId)
        {
            throw new InvalidMemberException("Already The Member Type Is Same");
        }
        member.MemberTypeId = MemberTypeId;
        var updatedMember = memberRepository.Update(member.MemberId,member);
        return updatedMember;
    }
}
