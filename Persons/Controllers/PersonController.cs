using Microsoft.AspNetCore.Mvc;
using Persons.Common;
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
        private IPersonRepository PersonRepository { get; set; }

        public PersonController(ICrudRepository<PersonDto> repository, IPersonRepository personRepository)
            : base(repository)
        {
            PersonRepository = personRepository;
        }

        [HttpGet("/fromcompany/{id:int}")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetByCompanyId(int id)
        {
            var result = await PersonRepository.GetByCompanyId(id);
            return result != null
                ? Ok(result)
                : (ActionResult)NotFound();
        }
    }
}
