using LibraryManagementAPI.DTOs;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;

namespace LibraryManagementAPI.Services;

public class LibraryService:ILibraryService
{
    private readonly ILibraryRepository _repository;

    public LibraryService(ILibraryRepository repository)
    {
        _repository = repository;
    }
    public async Task<Book> AddBook(Book book)
    {
        _repository.AddBooks(book);
        await _repository.SaveChanges();
        return book;
    }

    public async Task<Member> AddMember(Member member)
    {
        _repository.AddMembers(member);
        await _repository.SaveChanges();
        return member;
    }
    
    public async Task<Loan> BorrowBookAsync(LoanDto dto)
    {

        var book = await _repository.GetBookById(dto.BookId);
    
        if (book == null) 
        {
            throw new KeyNotFoundException("Book not found.");
        }

        if (book.AvailableCopies <= 0)
        {
            throw new InvalidOperationException("No copies available.");
        }


        book.AvailableCopies -= 1;

        
        var loan = new Loan
        {
            BookID = dto.BookId,      
            MemberId = dto.MemberId,
            BorrowedAt = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(14)
        };

        _repository.AddLoan(loan);
        
        await _repository.SaveChanges();

        return loan;
    }
    
    public async Task<IEnumerable<LoanResponseDto>> GetAllLoansAsync()
    {
        var loans = await _repository.GetAllLoans();

        return loans
            .Where(l => l.member != null) 
            .Select(l => new LoanResponseDto
            {
                LoanId = l.Id,
                BookTitle = l.book.Title,     
                MemberName = l.member.FullName,
                BorrowedAt = l.BorrowedAt,
                DueDate = l.DueDate
            })
            .ToList();
    }
    
}