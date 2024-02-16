using API.Source.Base.Contracts.Service;
using API.Source.Base.Middleware;
using API.Source.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Auth([FromBody] AuthRequest request)
        {
            try
            {
                return BuildResponse(await _service.Auth(request), message: "Logado com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }
    }
}
