using Microsoft.EntityFrameworkCore;
using Persons.DataLayer.Entities;

namespace Persons.DataLayer
{
    public class Context : DbContext
    {
        DbSet<Company> Companies { get; set; }

        DbSet<Person> Persons { get; set; }

        DbSet<Passport> Passports { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
