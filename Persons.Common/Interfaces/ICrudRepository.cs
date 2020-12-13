using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Common.Interfaces
{
    public interface ICrudRepository<TDto> where TDto : class
    {
        Task<int> CreateAsync(TDto item);

        Task<bool> UpdateAsync(TDto item);

        Task<bool> DeleteAsync(int id);

        Task<TDto> FindByIdAsync(int id);

        Task<IEnumerable<TDto>> GetAsync();
    }
}
