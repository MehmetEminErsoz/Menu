using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : GenericController<City_DTO>
    {
        IGenericService<City_DTO> service;
        public CityController(IGenericService<City_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
