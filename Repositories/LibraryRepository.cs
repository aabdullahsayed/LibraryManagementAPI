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

    public void Add(Book book)
    {
        _context.books.Add(book);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}