using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressTypeController : GenericController<AdressType_DTO>
    {
        IGenericService<AdressType_DTO> service;
        public AdressTypeController(IGenericService<AdressType_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
