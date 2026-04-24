namespace LibraryManagementAPI.DTOs;

public class LoanResponseDto
{
    public int LoanId { get; set; }
    public string BookTitle { get; set; } 
    public string MemberName { get; set; }
    public DateTime BorrowedAt { get; set; }
    public DateTime DueDate { get; set; }
}