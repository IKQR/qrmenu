using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace QRCodeMenu.Server.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public async Task<IActionResult> Error()
        {
            await Task.CompletedTask;

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            return BadRequest(exception);
        }
    }
}
