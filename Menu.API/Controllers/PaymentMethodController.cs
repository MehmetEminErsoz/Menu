using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : GenericController<PaymentMethod_DTO>
    {
        IGenericService<PaymentMethod_DTO> service;
        public PaymentMethodController(IGenericService<PaymentMethod_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}