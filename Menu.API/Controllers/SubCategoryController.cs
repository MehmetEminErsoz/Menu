using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : GenericController<SubCategory_DTO>
    {
        IGenericService<SubCategory_DTO> service;
        public SubCategoryController(IGenericService<SubCategory_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}