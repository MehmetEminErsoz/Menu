using Menu.API.Concrete;
using Menu.API.Models;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : GenericController<Person_DTO>
    {

        IPersonService service;
        public PersonController(IPersonService _service) : base(_service)
        {
            service = _service;

        }

        [HttpPost("getByEmail")]
        public IActionResult Get([FromBody] mailModel mail)
        {
            var param = mail.Email;
            var result = service.getByEmail(param);
            if (result != null)
            {
                return Ok(result);

            }

            return NotFound();
          
           
        }
        

    }
}