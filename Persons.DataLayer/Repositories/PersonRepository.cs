using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using Persons.DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.DataLayer.Repositories
{
    public class PersonRepository : BaseRepository<Person, PersonDto>, IPersonRepository
    {
        public PersonRepository(IMapper mapper, Context dbContext)
            : base(mapper, dbContext)
        { }

        public async Task<IEnumerable<PersonDto>> GetByCompanyIdAsync(int companyId)
        {
            var result = await dbSet.AsNoTracking().Where(x =>x.CompanyId.Equals(companyId)).ToListAsync();
            return mapper.Map<IEnumerable<PersonDto>>(result);
        }

        public async Task<bool> UpdatePartialAsync(int id, UpdatePersonDto dto)
        {
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entity.Name != dto.Name && !string.IsNullOrWhiteSpace(dto.Name))
            {
                entity.Name = dto.Name;
            }
            if (entity.Surname != dto.Surname && !string.IsNullOrWhiteSpace(dto.Surname))
            {
                entity.Surname = dto.Surname;
            }
            if (entity.Phone != dto.Phone && !string.IsNullOrWhiteSpace(dto.Phone))
            {
                entity.Phone = dto.Phone;
            }
            if (entity.CompanyId != dto.CompanyId && dto.CompanyId.HasValue)
            {
                entity.CompanyId = dto.CompanyId.Value;
            }

            return await DbContext.SaveChangesAsync() == 1;
        }
    }
}