using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : GenericController<Package_DTO>
    {
        IGenericService<Package_DTO> service;
        public PackageController(IGenericService<Package_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}