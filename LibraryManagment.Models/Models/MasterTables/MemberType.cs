namespace LibraryManagement.Models;

public class MemberType
{
    public int MemberTypeId {get;set;}
    public string MemberTypeName {get;set;} = string.Empty;
    public int NumberOfBooks {get;set;}
    public int LimitDays {get;set;}
    public ICollection<Member> Members { get; set; } = new List<Member>();
}