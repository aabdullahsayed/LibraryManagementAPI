using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services;

public interface ILibraryService
{
    Book AddBook(Book book);
   Member AddMember(Member member);
}