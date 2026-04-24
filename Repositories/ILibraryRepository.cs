using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public interface ILibraryRepository
{
    void AddBooks(Book book);
    void AddMembers(Member member);
    Task SaveChanges();
    
    Task<Book> GetBookById(int id);
    void AddLoan(Loan loan);
    
    Task<IEnumerable<Loan>> GetAllLoans();
}