namespace LibraryManagement.Models;

public class Member
{
    public int MemberId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool isActive { get; set; }
    public int? MemberTypeId { get; set; }
    public MemberType? MemberType { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public DateTime createdAt { get; set; }
    public DateTime? updatedAt { get; set; }

    public ICollection<DamagedBook> DamagedBooks { get; set; } = new List<DamagedBook>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    public override string ToString()
    {
        string basicMemberDetails = "----------- Member Details -----------";
        string member = $"MemberId : {MemberId}\nFirsName : {FirstName}\nLastName : {LastName}\nEmail : {Email}\nPhoneNumber : {PhoneNumber}\nRole : {Role?.RoleName}\n";
        if (RoleId == 2)
        {
            member = member + $"Member Type : {MemberType?.MemberTypeName}\n";
        }
        member = member + $"IsActive : {isActive}\nCreated At : {createdAt}\n" ;
        if (updatedAt != null)
        {
            member = member + $"Updated At : {updatedAt}\n";
        }
        return "\n\n" + basicMemberDetails + "\n\n" + member;
    }
}