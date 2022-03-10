using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : GenericController<Desk_DTO>
    {
        IGenericService<Desk_DTO> service;
        public DeskController(IGenericService<Desk_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
