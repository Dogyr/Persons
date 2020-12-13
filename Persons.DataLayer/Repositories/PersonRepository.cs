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

        public async Task<IEnumerable<PersonDto>> GetByCompanyId(int companyId)
        {
            var result = await dbSet.AsNoTracking().Where(x =>x.CompanyId.Equals(companyId)).ToListAsync();
            return mapper.Map<IEnumerable<PersonDto>>(result);
        }
    }
}
