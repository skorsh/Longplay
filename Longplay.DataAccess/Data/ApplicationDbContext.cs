using Longplay.Model;
using Microsoft.EntityFrameworkCore;

namespace Longplay.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 
    }
}
