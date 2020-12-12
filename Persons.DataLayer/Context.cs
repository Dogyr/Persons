using Microsoft.EntityFrameworkCore;
using Persons.DataLayer.Entities;

namespace Persons.DataLayer
{
    public class Context : DbContext
    {
        DbSet<Company> Companies { get; set; }

        DbSet<Person> Persons { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
    }
}
