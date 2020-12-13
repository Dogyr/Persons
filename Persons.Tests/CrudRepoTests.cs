using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Persons.Common.Dtos;
using Persons.DataLayer.Entities;
using Persons.DataLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Persons.Tests
{
    public class CrudRepoTests : TestDb
    {
        private readonly BaseRepository<Person, PersonDto> _repository;

        public CrudRepoTests()
        {
            var entityPerson = new Person()
            { 
                Name = "Tom",
                Surname = "Cruise",
                Phone = "88005553535"
            };
            DbContext.Persons.AddAsync(entityPerson);
            DbContext.SaveChangesAsync();


            _repository = new BaseRepository<Person, PersonDto>(Mapper, DbContext);
        }

        [Fact]
        public async Task TestGetIsSucces()
        {
            var result = await _repository.GetAsync();

            Assert.IsType<List<PersonDto>>(result);
        }

        [Fact]
        public async Task TestFindByIdIsSucces()
        {
            var entityPerson = Fixture.Build<Person>()
                .Without(x => x.Id)
                .Without(x => x.Company)
                .Create();
            await DbContext.Persons.AddAsync(entityPerson);
            await DbContext.SaveChangesAsync();

            var result = await _repository.FindByIdAsync(entityPerson.Id);

            Assert.IsType<PersonDto>(result);
        }

        [Fact]
        public async Task TestFindByIdIsNull()
        {
            var id = 1000;

            var result = await _repository.FindByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task TestCreateIsSucces()
        {
            var dto= Fixture.Build<PersonDto>()
                .Without(x => x.Id)
                .Create();

            var result = await _repository.CreateAsync(dto);

            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task TestDeleteIsTrue()
        {
            var entity = await DbContext.Persons.FirstOrDefaultAsync();
            DbContext.Entry(entity).State = EntityState.Detached;

            var result = await _repository.DeleteAsync(entity.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task TestDeleteIsFalse()
        {
            var result = await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(() => _repository.DeleteAsync(1000));

            Assert.Equal("Attempted to update or delete an entity that does not exist in the store.", result.Message);
        }

        [Fact]
        public async Task TestUpdateIsTrue()
        {
            var item = await DbContext.Persons.FirstOrDefaultAsync();
            var entity = Mapper.Map<PersonDto>(item);
            DbContext.Entry(item).State = EntityState.Detached;
            entity.Name = "ASd";

            var result = await _repository.UpdateAsync(entity);

            Assert.True(result);
        }

        [Fact]
        public async Task TestUpdateTestIsExc()
        {
            var item = Fixture.Create<PersonDto>();

            var result = await Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(() => _repository.UpdateAsync(item));

            Assert.Equal("Attempted to update or delete an entity that does not exist in the store.", result.Message);
        }
    }
}
