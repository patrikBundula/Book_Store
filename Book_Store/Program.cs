using Book_Store;
using Book_Store.Services;
using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseMySql(
        databaseConnectionString,
        ServerVersion.AutoDetect(databaseConnectionString),
        o => o.MigrationsAssembly("Book_Store").EnableRetryOnFailure()
        );
});

builder.Services.AddScoped<IBookAppService, BookStoreAppService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//var context = new BookStoreContext();
//var books = context.Books.Where(b => b.Author.Id == 1)
//    .OrderBy(c => c.Title)
//    .Select(c => new { BookTitle = c.Title, AuthorName = c.Author.Name });

//foreach (var b in books)
//{
//    Console.WriteLine(b);
//}

//var groups = context.Books.GroupBy(c => c.Category);

//foreach (var group in groups)
//{
//    Console.WriteLine(group.Key + ": ");

//    foreach (var book in group)
//    {
//        Console.WriteLine("\t" + book.Title);
//    }
//}

//Join

//var books = context.Books.Join(context.Authors,
//    book => book.Author.Id,
//    author => author.Id,
//    (book, author) => new
//    {
//        BookTitle = book.Title,
//        Author = author.Name
//    });

//foreach (var b in books)
//{
//    Console.WriteLine(b);
//}

//List of categories and number of book they include, sorted by the number of books.
//Category with the highest number of book come first.


//var categories = context.Categories.GroupBy(c => c.Name);
//var books = context.Books.GroupBy(b => b.Category.Name)
//    .Select(x => new
//    {
//        CategoryName = x.Key,
//        Count = x.Count(),
//    });

//foreach (var b in books)
//{
//    Console.WriteLine(b);
//}


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
