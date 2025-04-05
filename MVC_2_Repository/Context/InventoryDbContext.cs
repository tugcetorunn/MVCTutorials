using Microsoft.EntityFrameworkCore;
using MVC_2_Repository.Models;

namespace MVC_2_Repository.Context
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }

    }
}
