using BeFit.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        protected static IActionResult ControllerResponse<T>(ServiceResponse<T> response)
            => new ObjectResult(response) { StatusCode = response.StatusCode };
    }
}
