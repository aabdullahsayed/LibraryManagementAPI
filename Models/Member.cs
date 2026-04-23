namespace LibraryManagementAPI.Models;

public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string email { get; set; }
    public bool IsActive { get; set; }
}