using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuPackageProduct_CController : GenericController<MenuPackageProduct_C_DTO>
    {
        IGenericService<MenuPackageProduct_C_DTO> service;
        public MenuPackageProduct_CController(IGenericService<MenuPackageProduct_C_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}