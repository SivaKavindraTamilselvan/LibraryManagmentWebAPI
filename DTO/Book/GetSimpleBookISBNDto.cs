namespace LibraryManagement.DTOs;

public class GetSimpleBookISBNDTO
{
    public int BookISBNId { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int Edition { get; set; }
}