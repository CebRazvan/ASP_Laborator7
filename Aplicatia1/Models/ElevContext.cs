using Microsoft.EntityFrameworkCore;

namespace Aplicatia1.Models
{
    public class ElevContext : DbContext
    {
        public ElevContext(DbContextOptions<ElevContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Elev> Elevi {  get; set; }
    }
}
