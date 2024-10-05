using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Domain.Enums;
using Inventory.Api.Module.Shared.Application.Util;

namespace Inventory.Api.Module.Inventory.Application.Service
{
	public class UnitMeasureService : IUnitMeasureService
	{
		public IEnumerable<UnitMeasureDto> GetAllUnitMeasures()
		{
			var unitMeasures = ReflexionEnum.ListValues<UnitMeasure>();
			return from unit in unitMeasures select new UnitMeasureDto(unit.Value, unit.Key);
		}
	}
}