using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : GenericController<Adress_DTO>
    {
        IGenericService<Adress_DTO> service;
        public AdressController(IGenericService<Adress_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
