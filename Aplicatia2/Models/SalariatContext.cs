using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Aplicatia2.Models;

namespace Aplicatia2.Models
{
    public class SalariatContext : DbContext
    {
        public SalariatContext(DbContextOptions<SalariatContext> options) :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Aplicatia2.Models.Salariat> Salariat { get; set; } = default!;
    }
}
