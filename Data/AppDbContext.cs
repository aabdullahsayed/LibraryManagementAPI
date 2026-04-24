using LibraryManagementAPI.Interceptors;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                    .HasMaxLength(150);

                entity.Property(b => b.ISBN)
                    .IsRequired().
                    HasMaxLength(17);
                entity.HasIndex(b => b.ISBN)
                    .IsUnique();
            } 
        );

        modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(m => m.email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasIndex(m => m.email)
                    .IsUnique();

                entity.Property(m => m.IsActive).HasDefaultValue(true);
                
                entity.HasQueryFilter(m => m.IsActive == true);
            } 
        );
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}