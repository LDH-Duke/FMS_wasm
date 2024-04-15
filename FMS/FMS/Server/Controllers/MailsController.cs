using FMS.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        [HttpPost]
        public async ValueTask<IActionResult> Post([FromBody]MailInfo models)
        {


            return Ok();
        }
    }
}
