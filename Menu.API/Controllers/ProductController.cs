using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : GenericController<Product_DTO>
    {
        IGenericService<Product_DTO> service;
        public ProductController(IGenericService<Product_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}