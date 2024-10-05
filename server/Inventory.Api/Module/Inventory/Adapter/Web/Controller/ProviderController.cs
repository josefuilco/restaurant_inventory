using Inventory.Api.Module.Inventory.Adapter.Web.Request;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.Inventory.Adapter.Web.Controller
{
	[ApiController]
	[Route("api/v1.0/[controller]")]
	public class ProviderController : ControllerBase
	{
		private readonly IProviderService service;
		private readonly ILogger<ProviderController> logger;
		
		public ProviderController(IProviderService service, ILogger<ProviderController> logger)
		{
			this.service = service;
			this.logger = logger;
		}

		#region Endpoints
		[HttpGet]
		[Route("list")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var providers = await service.GetAllProvidersAsync();
				var response = new{
					message = "Proveedores Encontrados",
					data = providers
				};
				logger.LogInformation("Proveedores: {providers}", providers);
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateProvider([FromBody] CreateProviderRequest requestBody)
		{
			try
			{
				var isCreated = await service.CreateProviderAsync(new(
					0,
					new(requestBody.Name),
					new(requestBody.Cellphone),
					true
				));
				var response = new{
					message = "Proveedor Creado",
					data = isCreated
				};
				logger.LogInformation("Proveedor Creado");
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> UpdateProvider([FromBody] UpdateProviderRequest requestBody)
		{
			try
			{
				var isUpdated = await service.UpdateProviderAsync(new(
					requestBody.Id,
					new("default-name"),
					new(requestBody.Cellphone),
					true
				));
				var response = new{
					message = "Proveedor Actualizado",
					data = isUpdated
				};
				logger.LogInformation("Proveedor Actualizado");
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}

		[HttpPut]
		[Route("remove/{id}")]
		public async Task<IActionResult> RemoveProvider(int id)
		{
			try
			{
				var isDeleted = await service.DeleteProviderAsync(id);
				var response = new{
					message = "Proveedor Eliminado",
					data = isDeleted
				};
				logger.LogInformation("Proveedor Eliminado");
				return Ok(response);
			}
			catch (Exception ex)
			{
				var response = new{
					message = ex.Message,
					data = false
				};
				logger.LogError("Failed in {ex.Message}", ex.Message);
				return StatusCode(500, response);
			}
		}
		#endregion
	}
}