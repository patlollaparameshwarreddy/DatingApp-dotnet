using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class DatingDbContext : DbContext
    {
        public DatingDbContext(DbContextOptions<DatingDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
