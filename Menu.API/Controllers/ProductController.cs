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
        IProductService Service;
        
        public ProductController(IProductService _service) : base(_service)
        {
            Service = _service;
        }

        [HttpGet("getByIdCompany/{idCompany}")]
        public IActionResult Get(int idCompany)
        {

            var result = Service.getByIdCompany(idCompany);
            if (result != null)
            {
                return Ok(result);

            }

            return NotFound();
        }
    }
}