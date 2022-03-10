using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : GenericController<Category_DTO>
    {
        IGenericService<Category_DTO> service;
        public CategoryController(IGenericService<Category_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
