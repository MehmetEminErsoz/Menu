using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageProduct_CController : GenericController<PackageProduct_C_DTO>
    {
        IGenericService<PackageProduct_C_DTO> service;
        public PackageProduct_CController(IGenericService<PackageProduct_C_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}