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
        IGenericService<User_DTO> service;
        public UserController(IGenericService<User_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}