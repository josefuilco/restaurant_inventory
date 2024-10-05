using Inventory.Api.Module.Inventory.Application.Dto;

namespace Inventory.Api.Module.Inventory.Application.Port.Service
{
    public interface IUnitMeasureService
    {
        IEnumerable<UnitMeasureDto> GetAllUnitMeasures();
    }
}