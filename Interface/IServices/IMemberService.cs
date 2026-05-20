using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IMemberService
{
    public GetMemberDTO? AddMemberService(CreateMemberDTO createMemberDTO);
    public List<GetMemberDTO> GetAllMembers();
    public GetMemberDTO? GetMemberByEmail(string email);
    public GetMemberDTO? GetMemberByPhoneNumber(string email);
    public List<GetMemberDTO> GetMemberByRole(int RoleId);
    public GetMemberDTO? GetMemberById(int MemberId);
    public GetMemberDTO? UpdateTheMemberTypeByMemberId(int id, int MemberTypeId);
    public GetMemberDTO? UpdateTheMemberTypeByEmail(string email, int MemberTypeId);
    public GetMemberDTO? ActivateTheMemberByMemberId(int id);
    public GetMemberDTO? ActivateTheMemberByEmail(string email);
    public GetMemberDTO? ActivateTheMemberByPhoneNumber(string PhoneNumber);
    public GetMemberDTO? DeactivateTheMemberByMemberId(int id);
    public GetMemberDTO? DeactivateTheMemberByEmail(string email);
    public GetMemberDTO? DeactivateTheMemberByPhoneNumber(string PhoneNumber);
}