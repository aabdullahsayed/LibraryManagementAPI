using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public interface ILibraryRepository
{
    void Add(Book book);
    bool SaveChanges();
}