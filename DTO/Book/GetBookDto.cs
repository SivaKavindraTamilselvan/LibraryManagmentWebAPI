namespace LibraryManagement.DTOs;

public class GetBookDTO
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public string BookCategoryName { get; set; } = string.Empty;

    public List<GetBookISBNDTO> ISBNs { get; set; } = new();
}