using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }


}
