using Microsoft.EntityFrameworkCore;

namespace Lab5.Models
{
    public class PhonesContext : DbContext
    {
        public DbSet<Phones> Phones { get; set; }

        public PhonesContext(DbContextOptions<PhonesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
