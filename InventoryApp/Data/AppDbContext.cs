using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Product> Products { get; set; }
    }
}

