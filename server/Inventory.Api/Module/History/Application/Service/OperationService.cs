using Inventory.Api.Module.History.Application.Dto;
using Inventory.Api.Module.History.Application.Port.Service;
using Inventory.Api.Module.History.Domain.Enums;
using Inventory.Api.Module.Shared.Application.Util;

namespace Inventory.Api.Module.History.Application.Service
{
    public class OperationService : IOperationService
    {
        public IEnumerable<OperationDto> GetOperations()
        {
            var operations = ReflexionEnum.ListValues<Operation>();
            return operations.Select(operation => new OperationDto(operation.Value, operation.Key));
        }
    }
}