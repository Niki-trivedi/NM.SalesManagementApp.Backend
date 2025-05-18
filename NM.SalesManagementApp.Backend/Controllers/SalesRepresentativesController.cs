using Microsoft.AspNetCore.Mvc;
using NM.SalesManagementApp.Backend.Models;
using NM.SalesManagementApp.Backend.Repositories;
using System.Threading.Tasks;

namespace NM.SalesManagementApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepresentativesController : ControllerBase
    {
        private readonly ISalesRepRepository _repository;
        public SalesRepresentativesController(ISalesRepRepository repository) => _repository = repository;

        /// <summary>
        /// get all sales Representative data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        /// <summary>
        /// get sales Representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rep = await _repository.GetByIdAsync(id);
            return rep == null ? NotFound() : Ok(rep);
        }

        /// <summary>
        /// add sales Representative
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalesRepresentative rep)
        {
            await _repository.AddAsync(rep);
            return CreatedAtAction(nameof(Get), new { id = rep.Id }, rep);
        }

        /// <summary>
        /// update sales Representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rep"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SalesRepresentative rep)
        {
            if (id != rep.Id) return BadRequest();
            await _repository.UpdateAsync(rep);
            return NoContent();
        }

        /// <summary>
        /// delete sales Representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
