using Inventory.Api.Module.History.Domain.Enums;

namespace Inventory.Api.Module.History.Application.Dto
{
    public record ProductHistoryDto(
        int Id,
        int CurrentAmount,
        int LatestAmount,
        int TotalAmountDiference,
        DateTime HistoryDate,
        string ProductName,
        string UserName,
        string OperationName,
        string Description
    );
}