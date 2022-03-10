using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : GenericController<Customer_DTO>
    {
        IGenericService<Customer_DTO> service;
        public CustomerController(IGenericService<Customer_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
