namespace Inventory.Api.Module.History.Adapter.Web.Request
{
    public record HistoryRequest(int ProductId, DateTime From, DateTime To);
}