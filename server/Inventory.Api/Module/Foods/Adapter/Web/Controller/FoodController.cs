using Inventory.Api.Module.Foods.Adapter.Web.Request;
using Inventory.Api.Module.Foods.Application.Dto;
using Inventory.Api.Module.Foods.Application.Port.Service;
using Inventory.Api.Module.Foods.Domain.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.Foods.Adapter.Web.Controller
{
	[ApiController]
	[Route("api/v1.0/[controller]")]
	public class FoodController : ControllerBase
	{
		private readonly IFoodService foodService;
		private readonly IFoodTypeService typeService;
		private readonly ILogger<FoodController> logger;

		public FoodController(IFoodService foodService, IFoodTypeService typeService, ILogger<FoodController> logger)
		{
			this.foodService = foodService;
			this.typeService = typeService;
			this.logger = logger;
		}

		#region Endpoints
		[HttpGet]
		[Route("list")]
		public async Task<IActionResult> GetAllFood()
		{
			try
			{
				var foodList = await foodService.GetAllFoodAsync();
				var response = new{
					message = "Foods Found",
					data = foodList
				};
				logger.LogInformation("Foods are {foodList}", foodList);
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
		[HttpGet]
		[Route("types")]
		public IActionResult GetFoodTypes()
		{
			try
			{
				var foodTypes = typeService.GetFoodTypes();
				var response = new{
					message = "Foods Found",
					data = foodTypes
				};
				logger.LogInformation("Food Types are {foodTypes}", foodTypes);
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
		public async Task<IActionResult> CreateFood([FromBody] FoodRequest requestBody)
		{
			try
			{
				var builder = new FoodBuilder();
				var isCreated = await foodService.CreateFoodAsync(builder.AddName(requestBody.Name)
				.AddPrice(requestBody.Price)
				.AddAmount(requestBody.Amount)
				.AddType((short)requestBody.Type)
				.Build());
				var response = new{
					message = "Foods Found",
					data = isCreated
				};
				logger.LogInformation("Food Created is {requestBody.Name}", requestBody.Name);
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
		[Route("update/{id}")]
		public async Task<IActionResult> CreateFood(int id, [FromBody] FoodRequest requestBody)
		{
			try
			{
				var builder = new FoodBuilder();
				var isUpdated = await foodService.UpdateFoodAsync(builder.AddId(id)
				.AddName(requestBody.Name)
				.AddPrice(requestBody.Price)
				.AddAmount(requestBody.Amount)
				.AddType((short)requestBody.Type)
				.Build());
				var response = new{
					message = "Food Updated",
					data = isUpdated
				};
				logger.LogInformation("Food Updated is {id}", id);
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
		public async Task<IActionResult> RemoveFood(int id)
		{
			try
			{
				var isRemoved = await foodService.DeleteFoodAsync(id);
				var response = new{
					message = "Food Removed",
					data = isRemoved
				};
				logger.LogInformation("Food Removed is {id}", id);
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