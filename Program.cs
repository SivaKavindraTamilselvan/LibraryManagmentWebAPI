using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DataAccessLibrary.DBContext;
using LibraryManagement.Interfaces;
using LibraryManagement.Repositories;
using LibraryManagement.UniqueNumbers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Contexts
builder.Services.AddDbContext<LibraryManagementContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
#endregion


#region Repositories
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
builder.Services.AddScoped<IBookISBNRepository, BookISBNRepository>();
builder.Services.AddScoped<IBookCopyRepository, BookCopyRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();
builder.Services.AddScoped<IDamagedRepository, DamagedBookRepository>();
builder.Services.AddScoped<IFineRepository, FineRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<GenerateUnique>();
#endregion

#region Services
builder.Services.AddScoped<IBorrowingService,BorrowingService>();
builder.Services.AddScoped<IMemberService,MemberService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IReturnService,ReturnService>();
builder.Services.AddScoped<IPaymentService,PaymentService>();
builder.Services.AddScoped<IFineService,FineService>();

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
