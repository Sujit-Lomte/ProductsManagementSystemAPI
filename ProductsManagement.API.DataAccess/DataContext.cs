using ProductsManagement.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductsManagement.API.DataAccess;
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbSet<Product> Products { get; set; }

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("ProductDb");
    }
}