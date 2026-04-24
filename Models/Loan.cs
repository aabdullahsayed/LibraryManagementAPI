namespace LibraryManagementAPI.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookID { get; set; }
    public int MemberId { get; set; }
    public DateTime BorrowedAt { get; set; }
    public DateTime DueDate { get; set; }
    public Book book { get; set; }
    public Member member { get; set;}
}