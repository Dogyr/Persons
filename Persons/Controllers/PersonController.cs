using Microsoft.AspNetCore.Mvc;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : CrudControllerBase<PersonDto>
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(ICrudRepository<PersonDto> repository, IPersonRepository personRepository)
            : base(repository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("/fromcompany/{id:int}")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetByCompanyId(int id)
        {
            var result = await _personRepository.GetByCompanyIdAsync(id);
            return result != null
                ? Ok(result)
                : (ActionResult)NotFound();
        }

        [HttpPut("{id:int}/partial")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdatePersonDto request)
        {
            var item = await Repository.FindByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var result = await _personRepository.UpdatePartialAsync(id, request);
            return Ok(result);
        }
    }
}
