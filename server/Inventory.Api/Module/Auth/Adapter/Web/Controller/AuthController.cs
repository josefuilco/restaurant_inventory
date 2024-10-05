using Inventory.Api.Module.Auth.Adapter.Web.Request;
using Inventory.Api.Module.Auth.Application.Port.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.Auth.Adapter.Web.Controller
{
	[ApiController]
	[Route("api/v1.0/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService service;
		private readonly ILogger<AuthController> logger;

		public AuthController(IAuthService service, ILogger<AuthController> logger)
		{
			this.service = service;
			this.logger = logger;
		}

		#region Endpoints
		[HttpPost]
		[Route("sign-in")]
		public async Task<IActionResult> SignIn([FromBody] SignInRequest requestBody)
		{
			try
			{
				var token = await service.AuthenticateUserAsync(requestBody.Username, requestBody.Password);
				var response = new{
					message = "Success",
					data = token,
				};
				logger.LogInformation("Token is {token}", token);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false,
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}
		#endregion
	}
}