namespace LibraryManagement.Models;

public class DamagedBook
{
    public int DamagedBookId { get; set; }
    public int MemberId { get; set; }
    public Member? Member { get; set; }
    public int BookCopyId { get; set; }
    public BookCopy? BookCopy { get; set; }
    public int DamagedLevelId { get; set; }
    public DamagedLevel? DamagedLevel { get; set; }
    public DateTime createdAt { get; set; }
    public Fine? Fines { get; set; }

    public override string ToString()
    {
        return $"DamagedBookId : {DamagedBookId}\nMemberId : {MemberId}\nBookCopyId : {BookCopyId}\nDamagedLevelId : {DamagedLevelId}";
    }

}