using Microsoft.EntityFrameworkCore;
using WebIEEE.Domain.Entities;

namespace WebIEEE.Infrastructure;

public class WebIeeeDbContext(DbContextOptions<WebIeeeDbContext> options) : DbContext(options)
{
    public DbSet<News> News { get; set; }
}