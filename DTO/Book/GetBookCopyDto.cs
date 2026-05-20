namespace LibraryManagement.DTOs;

public class GetBookCopyDTO
{
    public int BookCopyId { get; set; }
    public string CopyNumber { get; set; } = string.Empty;
    public int BookStatusId { get; set; }
    public string BookStatusName { get; set; } = string.Empty;
}