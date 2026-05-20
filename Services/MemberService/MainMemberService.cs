using LibraryManagement.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class MemberService : IMemberService
{
    protected readonly IMemberRepository memberRepository;
    public MemberService(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
       
    }
}