using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User_DTO>
    {
        
        IUserService service;
        public UserController(IUserService _service) : base(_service)
        {
            service = _service;
        }


        [HttpGet("getByEmail/{mail}")]
        public IActionResult Get(string mail)
        {

            var result = service.getByEmail(mail);
            if (result != null)
            {
                return Ok(result);

            }

            return NotFound();


        }
    }
}