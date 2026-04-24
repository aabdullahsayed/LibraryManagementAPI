using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories;

public class LibraryRepository:ILibraryRepository
{
    private readonly AppDbContext _context;
    
    public LibraryRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddBooks(Book book)
    {
        _context.books.Add(book);
    }

    public void AddMembers(Member member)
    {
        _context.members.Add(member);
    }

   
    
    public async Task<Book> GetBookById(int id)
    {
        return await _context.books.FindAsync(id);
    }
    
    public void AddLoan(Loan loan)
    {
        _context.loans.Add(loan);
    }
    
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
        
    }
    
    public async Task<IEnumerable<Loan>> GetAllLoans()
    {
        return await _context.loans
            .Include(l => l.book) 
            .Include(l => l.member) 
            .ToListAsync();
    }
    
}