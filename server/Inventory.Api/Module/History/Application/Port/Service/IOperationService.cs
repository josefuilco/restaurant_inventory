using Inventory.Api.Module.History.Application.Dto;

namespace Inventory.Api.Module.History.Application.Port.Service
{
    public interface IOperationService
    {
        IEnumerable<OperationDto> GetOperations();
    }
}