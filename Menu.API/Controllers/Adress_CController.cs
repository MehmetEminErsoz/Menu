using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Adress_CController : GenericController<Adress_C_DTO>
    {
        IGenericService<Adress_C_DTO> service;
        public Adress_CController(IGenericService<Adress_C_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
