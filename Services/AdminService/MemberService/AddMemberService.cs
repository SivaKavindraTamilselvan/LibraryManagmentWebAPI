using LibraryManagement.BuisnessLayerLibrary.Inputs;
using LibraryManagement.UniqueNumbers;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

// add member service
public partial class AdminService
{
    public Member? AddMemberService()
    {
        Member member = new Member();
        Console.WriteLine("Enter Your First Name");
        string FirstName = inputsCheck.NameInput();
        
        Console.WriteLine("\nEnter Your Last Name");
        string LastName = inputsCheck.NameInput();

        Console.WriteLine("\nEnter Your Email");
        string Email = inputsCheck.EmailInputs();
        if (GetMemberByEmail(Email) != null)
        {
            throw new InvalidMemberException("Already the Email Is Registered. Try With Another Email");
        }

        Console.WriteLine("\nEnter Your PhoneNumber");
        string PhoneNumber = inputsCheck.PhoneNumberInputs();
        if (GetMemberByPhoneNumber(PhoneNumber) != null)
        {
            throw new InvalidMemberException("Already the PhoneNumber Is Registered. Try With Another PhoneNumber");
        }

        Console.WriteLine("\nEnter The RoleType\n");
        Console.WriteLine("-- Enter 1 To Add Admin --");
        Console.WriteLine("-- Enter 2 To Add Member --\n");
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice < 0 || typechoice > 2)
        {
            Console.WriteLine("Enter Vaild Role Type Input");
        }

        if (typechoice == 2)
        {
            int memberchoice;
            Console.WriteLine("\nEnter The MemberType\n");
            Console.WriteLine("-- Enter 1 To Basic --");
            Console.WriteLine("-- Enter 2 To Student --");
            Console.WriteLine("-- Enter 3 To Premium --");
            while (!int.TryParse(Console.ReadLine(), out memberchoice) || memberchoice < 0 || memberchoice > 3)
            {
                Console.WriteLine("Enter Vaild Member Type Input");
            }
            member.MemberTypeId = memberchoice;
        }
        else
        {
            member.MemberTypeId = null;
        }

        //member detailed added to the object
        member.FirstName = FirstName;
        member.LastName = LastName;
        member.Email = Email;
        member.PhoneNumber = PhoneNumber;
        member.Password = FirstName + LastName + "123"; // initially added by the admin later can be changed by the user
        member.isActive = true;
        member.RoleId = typechoice;
        member.createdAt = DateTime.Now;
        var createdMember = memberRepository.Create(member);
        if (createdMember == null)
        {
            return null;
        }
        return createdMember;
    }
}
