using Book_Store;
using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Book_Store.Repositories;
using Book_Store.Service;

var _modelBuilder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = _modelBuilder.Configuration;

var databaseConnectionString = _modelBuilder.Configuration.GetConnectionString("DefaultConnection");

_modelBuilder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseMySql(
        databaseConnectionString,
        ServerVersion.AutoDetect(databaseConnectionString),
        o => o.MigrationsAssembly("Book_Store").EnableRetryOnFailure()
        );
});

_modelBuilder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
_modelBuilder.Services.AddScoped<ITokenService, TokenService>();
_modelBuilder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

_modelBuilder.Services.ConfigureIdentity(configuration);

// Add services to the container.

_modelBuilder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_modelBuilder.Services.AddEndpointsApiExplorer();
_modelBuilder.Services.AddSwaggerGen();

var app = _modelBuilder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();


