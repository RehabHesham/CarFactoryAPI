using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryAPI.Entities
{
    public class FactoryContext : DbContext
    {


        public FactoryContext() { }
        public FactoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UnitTest;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
    }
}
