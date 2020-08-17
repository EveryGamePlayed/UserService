using CoreServices.AuthenticationServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogInController : ControllerBase
    {


        private readonly ILogger<LogInController> _logger;
        private readonly IAuthenticationService _authService;

        public LogInController(ILogger<LogInController> logger,
            IAuthenticationService authService)
        {
            _logger = logger;
            _authService = authService;
        }

    }
}
