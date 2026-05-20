namespace LibraryManagement.Models;

public class FineCategory
{
    public int FineCategoryId {get;set;}
    public string FineCategoryName {get;set;} = string.Empty;
    public ICollection<Fine> Fines {get;set;} = new List<Fine>();
}