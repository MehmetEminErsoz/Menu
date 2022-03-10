using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : GenericController<Country_DTO>
    {
        IGenericService<Country_DTO> service;
        public CountryController(IGenericService<Country_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
