using NM.SalesManagementApp.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace NM.SalesManagementApp.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
    }
}
