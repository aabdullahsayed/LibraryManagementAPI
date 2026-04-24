using LibraryManagementAPI.DTOs;
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
    
    [HttpPost("books")]
    public async Task<IActionResult> AddBook(Book book)
    {
        return Ok(await _service.AddBook(book));
    }

    [HttpPost("members")]
    public async Task <IActionResult> AddMember(Member member)
    {
        return Ok(await _service.AddMember(member));
    }
    
    [HttpPost("loans")]
    public async Task<IActionResult> BorrowBook([FromBody] LoanDto request)
    {
        try
        {
            var loan = await _service.BorrowBookAsync(request);
            return Ok(loan);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    [HttpGet("loans")]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _service.GetAllLoansAsync();
    
        return Ok(loans);
    }
    
}