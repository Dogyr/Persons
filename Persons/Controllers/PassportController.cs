using Microsoft.AspNetCore.Mvc;
using Persons.Common;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : CrudControllerBase<PassportDto>
    {
        public PassportController(ICrudRepository<PassportDto> repository)
            : base(repository)
        { }
    }
}
