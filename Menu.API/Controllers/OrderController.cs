using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : GenericController<Order_DTO>
    {
        IGenericService<Order_DTO> service;
        public OrderController(IGenericService<Order_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}