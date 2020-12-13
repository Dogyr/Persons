using Persons.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Common.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonDto>> GetByCompanyIdAsync(int companyId);

        Task<bool> UpdatePartialAsync(int id, UpdatePersonDto dto);
    }
}