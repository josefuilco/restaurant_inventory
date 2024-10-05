using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Domain.Enums;
using Inventory.Api.Module.Shared.Application.Util;

namespace Inventory.Api.Module.Inventory.Application.Service
{
	public class CategoryService : ICategoryService
	{
		public IEnumerable<CategoryDto> GetAllCategories()
		{
			var categories = ReflexionEnum.ListValues<ProductCategory>();
			return from category in categories select new CategoryDto(category.Value, category.Key);
		}
	}
}