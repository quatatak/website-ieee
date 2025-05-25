using Microsoft.EntityFrameworkCore;
using WebIEEE.Infrastructure;
using WebIEEE.Application;
using WebIEEE.Server.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services from WebIEEE.Application
builder.Services.AddApplication();

// Add DbContext
var connectionString = builder.Configuration["PostgresDb"] ??
                       throw new InvalidOperationException("Database connection string not found");
builder.Services.AddDbContext<WebIeeeDbContext>(opt =>
{
    opt.UseNpgsql(connectionString);
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapFallbackToFile("/index.html");

// Add modules
app.AddNewsModule();

app.Run();
