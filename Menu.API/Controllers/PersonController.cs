using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : GenericController<Person_DTO>
    {
        IGenericService<Person_DTO> service;
        public PersonController(IGenericService<Person_DTO> _service) : base(_service)
        {
            service = _service;
        }


    }
}