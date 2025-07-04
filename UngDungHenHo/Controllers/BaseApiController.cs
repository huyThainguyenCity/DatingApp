using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UngDungHenHo.Helpers;

namespace UngDungHenHo.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
