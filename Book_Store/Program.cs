using Database;
using Logic.Repositories;
using Logic.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using Model.Interface;
using Sentry.Extensions.Logging.Extensions.DependencyInjection;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseMySql(
        databaseConnectionString,
        ServerVersion.AutoDetect(databaseConnectionString),
        o => o.MigrationsAssembly("Book_Store").EnableRetryOnFailure()
        );
});
builder.Logging.AddSentry();
builder.WebHost.UseSentry();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ConfigureIdentity(configuration);

builder.Services.AddOptions<AppConfig>()
    .Bind(builder.Configuration.GetSection("AppConfig"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var appConfig = app.Services.GetService<IOptions<AppConfig>>();
builder.Services.ConfigureFileDirectory(builder.Configuration, appConfig);

app.UseSentryTracing();

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


