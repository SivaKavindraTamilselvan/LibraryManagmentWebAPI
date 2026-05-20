namespace LibraryManagement.DTOs;

public class GetBookISBNDTO
{
    public int BookISBNId { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int Edition { get; set; }

    public List<GetBookCopyDTO> Copies { get; set; } = new();
}