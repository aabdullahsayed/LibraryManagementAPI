using LibraryManagementAPI.DTOs;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services;

public interface ILibraryService
{
    Task<Book> AddBook(Book book);
   Task<Member> AddMember(Member member);
   Task<Loan> BorrowBookAsync(LoanDto dto);
   Task<IEnumerable<LoanResponseDto>> GetAllLoansAsync();
}