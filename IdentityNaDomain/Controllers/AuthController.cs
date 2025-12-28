using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase {
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService) {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register() {
        var result = await _identityService.CreateUserAsync(
            "teste@email.com",
            "Senha@123",
            "Usuário Teste");

        return result ? Ok() : BadRequest();
    }
}
