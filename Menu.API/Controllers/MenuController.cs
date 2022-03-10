using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : GenericController<Menu_DTO>
    {
        IGenericService<Menu_DTO> service;
        public MenuController(IGenericService<Menu_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}