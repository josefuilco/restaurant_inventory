namespace Inventory.Api.Module.Inventory.Application.Dto
{
    public record ProductDto(
        int Id,
        string Name,
        decimal Price,
        int Quantity,
        int MinimalQuantity,
        string ProviderName,
        string CategoryName,
        string MeasureName
    );
}