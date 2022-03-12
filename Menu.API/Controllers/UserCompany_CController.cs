using Menu.API.Concrete;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Menu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCompany_CController : GenericController<UserCompany_C_DTO>
    {
        IGenericService<UserCompany_C_DTO> service;
        public UserCompany_CController(IGenericService<UserCompany_C_DTO> _service) : base(_service)
        {
            service = _service;
        }
    }
}