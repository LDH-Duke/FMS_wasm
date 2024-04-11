using FMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Users> User { get; set; }
    }
}
