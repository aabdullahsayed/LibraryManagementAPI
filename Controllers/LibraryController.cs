using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LibraryController:ControllerBase
{
    private readonly ILibraryService _service;

    public LibraryController(ILibraryService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        return Ok(_service.AddBook(book));
    }
}