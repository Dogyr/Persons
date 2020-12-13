using Persons.Common.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Common.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonDto>> GetByCompanyId(int companyId);
    }
}