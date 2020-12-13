using Microsoft.AspNetCore.Mvc;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudControllerBase<TDto> : ControllerBase
        where TDto : BaseDto
    {
        protected ICrudRepository<TDto> Repository { get; private set; }

        public CrudControllerBase(ICrudRepository<TDto> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            var result = await Repository.GetAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> Get(int id)
        {
            var result = await Repository.FindByIdAsync(id);
            return result != null
                ? Ok(result)
                : (ActionResult)NotFound();
        }

        [HttpPost()]
        public virtual async Task<ActionResult> Post([FromBody] TDto request)
        {
            var result = await Repository.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<ActionResult> Put(int id, [FromBody] TDto request)
        {
            var item = await Repository.FindByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            request.Id = item.Id;
            var result = await Repository.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<ActionResult> Remove(int id)
        {
            var item = await Repository.FindByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var result = await Repository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
