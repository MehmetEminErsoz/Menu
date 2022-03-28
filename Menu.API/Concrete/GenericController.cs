
using Menu.Business;
using Menu.Business.Abstract;
using Menu.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TargetDTO> : ControllerBase where TargetDTO : class, new()
    {
        IGenericService<TargetDTO> service;
        public GenericController(IGenericService<TargetDTO> _service)
        {
            service = _service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = service.getAll(true);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = service.getByID(id);
            if (result != null)
            {
                return Ok(result);

            }

            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] TargetDTO record)
        {
            var result = service.add(record);
           return CreatedAtAction("get", new { id = ((IDtoWithId)result).Id }, true); ;
        }


        [Authorize(Roles = "SAdmin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool sonuc
                = service.remove(id);

            if (sonuc)
            {
                return Ok(sonuc);
            }

            return NotFound();


        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TargetDTO record)
        {
            
            if (id != ((IDtoWithId)record).Id)
            {

                return BadRequest();
            }

            var result = service.update(id, record);
            if (result)
            {
                return AcceptedAtAction("get", new { id = id }, true);
            }
            return BadRequest();
        }
    }
}
