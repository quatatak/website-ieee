using Microsoft.EntityFrameworkCore;

namespace WebIEEE.Infrastructure;

public class WebIeeeDbContext(DbContextOptions<WebIeeeDbContext> options) : DbContext(options)
{
    
}