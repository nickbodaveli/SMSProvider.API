using Microsoft.EntityFrameworkCore;
using SMSProviders.API.Models;

namespace SMSProviders.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Provider> Providers { get; set; }
    }
}
