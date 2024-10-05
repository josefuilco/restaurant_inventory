using Inventory.Api.Module.Auth.Adapter.Web.Request;
using Inventory.Api.Module.Auth.Application.Port.Service;
using Inventory.Api.Module.Auth.Domain.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.Auth.Adapter.Web.Controller
{
	[ApiController]
	[Route("api/v1.0/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService service;
		private readonly ILogger<UserController> logger;

		public UserController(IUserService service, ILogger<UserController> logger)
		{
			this.service = service;
			this.logger = logger;
		}

		#region Endpoints
		[HttpGet]
		[Route("{token}")]
		public async Task<IActionResult> GetUserData(string token)
		{
			try
			{
				var user = await service.GetByTokenAsync(token);
				var response = new{
					message = "User Found",
					data = user,
				};
				logger.LogInformation("User is {user}", user.Name);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false,
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(401, response);
			}
		}
		[HttpGet]
		[Route("list")]
		public async Task<IActionResult> GetAllUser()
		{
			try
			{
				var users = await service.GetAllAsync();
				var response = new{
					message = "Users Found",
					data = users,
				};
				logger.LogInformation("Users: {users}", users);
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
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> AddNewUser([FromBody] SignUpRequest requestBody)
		{
			var builder = new UserBuilder();
			var isCreated = false;
			try
			{
				isCreated = await service.CreateUserAsync(builder.AddName(requestBody.Username)
				.AddPassword(requestBody.Password)
				.AddEmail(requestBody.Email)
				.AddRole((short)requestBody.Role)
				.Build());
				var response = new{
					message = "User Created",
					data = isCreated,
				};
				logger.LogInformation("User is {requestBody.Username}", requestBody.Username);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = isCreated,
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(401, response);
			}
		}
		[HttpPut]
		[Route("change-password/{id}")]
		public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest requestBody)
		{
			var isChanged = false;
			try
			{
				isChanged = await service.UpdatePasswordAsync(id, requestBody.CurrentPassword, requestBody.NewPassword);
				var response = new{
					message = "Password Changed",
					data = isChanged
				};
				logger.LogInformation("Password is Changed: {isChanged}", isChanged);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = isChanged
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(401, response);
			}
		}
		[HttpPut]
		[Route("remove/{id}")]
		public async Task<IActionResult> RemoveUser(int id)
		{
			var isRemoved = false;
			try
			{
				isRemoved = await service.DeleteAsync(id);
				var response = new{
					message = "User Removed",
					data = isRemoved
				};
				logger.LogInformation("User is Removed: {isRemoved}", isRemoved);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = isRemoved
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}
		#endregion
	}
}