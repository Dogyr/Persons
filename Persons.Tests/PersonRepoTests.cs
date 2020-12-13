using Microsoft.EntityFrameworkCore;
using Persons.Common.Dtos;
using Persons.DataLayer.Entities;
using Persons.DataLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Persons.Tests
{
    public class PersonRepoTests : TestDb
    {
        private readonly PersonRepository _repository;

        public PersonRepoTests()
        {
            var entityPerson = new Person()
            {
                Name = "Alexandr",
                Surname = "Anikeev",
                Phone = "88005553535",
                Company = new Company() 
                { 
                    Name = "Smartway" 
                }
            };
            DbContext.Persons.AddAsync(entityPerson);
            DbContext.SaveChangesAsync();

            _repository = new PersonRepository(Mapper, DbContext);
        }

        [Fact]
        public async Task TestGetByCompanyIdIsSuccess()
        {
            var entityPerson = await DbContext.Persons.FirstOrDefaultAsync();

            var result = await _repository.GetByCompanyIdAsync(entityPerson.CompanyId);

            Assert.IsType<List<PersonDto>>(result);
        }

        [Fact]
        public async Task TestUpdatePartialIsSuccess()
        {
            var entity = await DbContext.Persons.FirstOrDefaultAsync();
            var dto = new UpdatePersonDto()
            {
                Name = "Lol",
                CompanyId = 2
            };

            var result = await _repository.UpdatePartialAsync(entity.Id, dto);

            Assert.True(result);
        }
    }
}
