using LibraryManagementAPI.Data;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


app.Run();
