using Microsoft.EntityFrameworkCore;
using Persons.DataLayer.Entities;

namespace Persons.DataLayer
{
    public class Context : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
