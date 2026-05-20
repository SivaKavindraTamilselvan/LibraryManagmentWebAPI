using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.UniqueNumbers;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.DTOs;
using LibraryManagement.BuisnessLayerLibrary.Validation;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// add member service
public partial class AdminService
{
    public GetMemberDTO? AddMemberService(CreateMemberDTO createMemberDTO)
    {
        Member member = new Member();
        string FirstName = createMemberDTO.FirstName;
        string LastName = createMemberDTO.LastName;
        string Email = createMemberDTO.Email;
        string PhoneNumber = createMemberDTO.PhoneNumber;
        string Password = createMemberDTO.Password;
        int RoleId = createMemberDTO.RoleId;
        int? MemberId = createMemberDTO.MemberTypeId;

        NameValidation.isValidName(FirstName);
        NameValidation.isValidName(LastName);
        EmailValidation.isValidEmail(Email);
        PhoneNumberValidation.isValidPhoneNumber(PhoneNumber);
        if (GetMemberByEmail(Email) != null)
        {
            throw new InvalidMemberException("Already the Email Is Registered. Try With Another Email");
        }
        if (GetMemberByPhoneNumber(PhoneNumber) != null)
        {
            throw new InvalidMemberException("Already the PhoneNumber Is Registered. Try With Another PhoneNumber");
        }

        if (RoleId == 1 && MemberId != null)
        {
            throw new InvalidMemberException("Admin Cannot Have Member Type");
        }
        //member detailed added to the object
        member.FirstName = FirstName;
        member.LastName = LastName;
        member.Email = Email;
        member.PhoneNumber = PhoneNumber;
        member.Password = Password;
        member.isActive = true;
        member.RoleId = RoleId;
        member.MemberTypeId = MemberId;
        member.createdAt = DateTime.Now;
        var created = memberRepository.Create(member);
        if (created == null)
        {
            throw new InvalidMemberException("Member Not Created");
        }
        var fullMember = memberRepository.Get(created.MemberId);
        if (fullMember == null)
        {
            throw new InvalidMemberException("Member Not Found");
        }
        return new GetMemberDTO
        {
            MemberId = fullMember.MemberId,
            FirstName = fullMember.FirstName,
            LastName = fullMember.LastName,
            Email = fullMember.Email,
            PhoneNumber = fullMember.PhoneNumber,
            isActive = fullMember.isActive,
            Role = fullMember.Role?.RoleName ?? string.Empty,
            MemberType = fullMember.MemberType?.MemberTypeName ?? string.Empty,
            createdAt = fullMember.createdAt,
            updatedAt = fullMember.updatedAt
        };
    }
}
