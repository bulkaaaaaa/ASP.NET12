using Microsoft.EntityFrameworkCore;
using WebApplication12.Models;

namespace WebApplication12.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) {}

        public DbSet<Company> Companies { get; set; }
    }
}
