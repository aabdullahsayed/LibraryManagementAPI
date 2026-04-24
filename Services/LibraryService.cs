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
    public Book AddBook(Book book)
    {
        _repository.AddBooks(book);
        _repository.SaveChanges();
        return book;
    }

    public Member AddMember(Member member)
    {
        _repository.AddMembers(member);
        _repository.SaveChanges();
        return member;
    }
}