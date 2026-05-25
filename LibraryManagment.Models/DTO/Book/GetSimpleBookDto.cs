namespace LibraryManagement.DTOs;

public class GetSimpleBookDTO
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public string BookCategoryName { get; set; } = string.Empty;

}