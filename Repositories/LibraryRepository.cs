using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;

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
        _context.Add(member);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}