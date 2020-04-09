using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Commands;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Services;
using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly ITokensService _service;

        public IdentityController(ICommandDispatcher dispatcher, ITokensService service)
        {
            _dispatcher = dispatcher;
            _service = service;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            await _dispatcher.SendAsync(command);
            return Ok();
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<TokenDto>> SignIn([FromBody] SignIn command)
        {
            await _dispatcher.SendAsync(command);
            var token = _service.GetToken(command.Username);

            return Ok(token);
        }
    }
}