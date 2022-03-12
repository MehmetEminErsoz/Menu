using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : GenericController<State_DTO>
    {
        IGenericService<State_DTO> service;
        public StateController(IGenericService<State_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}