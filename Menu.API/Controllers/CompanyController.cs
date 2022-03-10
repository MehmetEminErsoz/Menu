using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : GenericController<Company_DTO>
    {
        IGenericService<Company_DTO> service;
        public CompanyController(IGenericService<Company_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
