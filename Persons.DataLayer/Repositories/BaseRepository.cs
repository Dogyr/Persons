using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persons.Common.Interfaces;
using Persons.DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.DataLayer.Repositories
{
    public class BaseRepository<TEntity, TDto> : ICrudRepository<TDto>
        where TEntity : BaseEntity, new()
        where TDto : class
    {
        protected readonly IMapper mapper;
        protected readonly DbSet<TEntity> dbSet;

        protected Context DbContext { get; private set; }

        public BaseRepository(IMapper mapper, Context dbContext)
        {
            this.mapper = mapper;
            dbSet = dbContext.Set<TEntity>();
            DbContext = dbContext;
        }

        public virtual async Task<int> CreateAsync(TDto item)
        {
            var newObject = mapper.Map<TEntity>(item);
            await dbSet.AddAsync(newObject);
            await DbContext.SaveChangesAsync();
            return newObject.Id;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var itemToRemove = new TEntity() { Id = id };
            dbSet.Attach(itemToRemove);
            dbSet.Remove(itemToRemove);
            return await DbContext.SaveChangesAsync() == 1;
        }

        public virtual async Task<TDto> FindByIdAsync(int id)
        {
            var result = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return mapper.Map<TDto>(result);
        }

        public virtual async Task<bool> UpdateAsync(TDto item)
        {
            var entity = mapper.Map<TEntity>(item);
            DbContext.Entry(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync() == 1;
        }

        public virtual async Task<IEnumerable<TDto>> GetAsync()
        {
            var entities = await dbSet.AsNoTracking().ToListAsync();
            return mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}