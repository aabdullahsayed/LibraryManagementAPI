using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> books { get; set; }
    public DbSet<Member> members { get; set; }
    public DbSet<Loan> loans { get; set; }
    public DbSet<AuditLog> auditlogs { get; set;}
    
}