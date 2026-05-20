using LibraryManagement.Interfaces;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public partial class MemberService
{
    protected readonly IMemberRepository memberRepository;
    public MemberService(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
       
    }
}