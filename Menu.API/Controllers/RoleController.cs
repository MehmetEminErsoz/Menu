using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role_DTO>
    {
        IGenericService<Role_DTO> service;
        public RoleController(IGenericService<Role_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}