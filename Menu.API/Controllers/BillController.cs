using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : GenericController<Bill_DTO>
    {
        IGenericService<Bill_DTO> service;
        public BillController(IGenericService<Bill_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}
