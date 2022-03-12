using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPackageProduct_CController : GenericController<OrderPackageProduct_C_DTO>
    {
        IGenericService<OrderPackageProduct_C_DTO> service;
        public OrderPackageProduct_CController(IGenericService<OrderPackageProduct_C_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}