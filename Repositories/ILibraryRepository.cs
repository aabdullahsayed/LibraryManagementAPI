using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public interface ILibraryRepository
{
    void AddBooks(Book book);
    void AddMembers(Member member);
    bool SaveChanges();
}