namespace LibraryManagement.DTOs;

public class GetMemberDTO
{
    public int MemberId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool isActive { get; set; }
    public string Role { get; set; } = string.Empty;
    public string MemberType {get;set;} = string.Empty;
    public DateTime createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
}