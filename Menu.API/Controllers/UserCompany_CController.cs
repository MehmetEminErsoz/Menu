using Menu.API.Concrete;
using Menu.API.Models;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCompany_CController : GenericController<UserCompany_C_DTO>
    {
        IUserCompany_CService service;
        public UserCompany_CController(IUserCompany_CService _service) : base(_service)
        {
            service = _service;
        }

        [HttpPost("SetByEmail/")]
        public IActionResult Post([FromBody] UserCompany_CModel model)
        {

            var result = service.SetRoleByEmail(model.Email,model.idCompany,model.idRole);
            if (result != null)
            {
                return Ok(result);

            }

            return NotFound();


        }
    }
}