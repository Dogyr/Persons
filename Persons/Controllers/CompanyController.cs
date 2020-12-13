using Microsoft.AspNetCore.Mvc;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : CrudControllerBase<CompanyDto>
    {
        public CompanyController(ICrudRepository<CompanyDto> repository)
            : base(repository)
        { }
    }
}
