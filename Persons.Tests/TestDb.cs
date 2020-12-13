using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persons.DataLayer;

namespace Persons.Tests
{
    public class TestDb
    {
        protected IFixture Fixture { get; }

        protected IMapper Mapper { get; }

        protected Context DbContext { get; }

        protected TestDb()
        {
            Fixture = new Fixture();

            Mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            })
                .CreateMapper();

            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase("fakeDb");
            DbContext = new Context(builder.Options);
        }
    }
}
