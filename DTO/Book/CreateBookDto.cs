namespace LibraryManagement.DTOs;

public class CreateBookDTO
{
    public string BookTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int BookCategoryId { get; set; }

}