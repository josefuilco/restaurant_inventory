using Inventory.Api.Module.History.Domain.Enums;

namespace Inventory.Api.Module.History.Domain.Model
{
	public class ProductHistory
	{
		public int Id { get; }
		public int CurrentQuantity { get; }
		public int LatestQuantity { get; }
		public DateTime HistoryDate { get; }
		public ProductInfo Product { get; }
		public Operation HistoryOperation { get; }
		public string UserName { get; }
		public string Detail { get; }

		public ProductHistory(int id, int currentAmount, int latestAmount, DateTime historyDate, ProductInfo product, Operation historyOperation, string userName, string detail)
		{
			Id = id;
			CurrentQuantity = currentAmount;
			LatestQuantity = latestAmount;
			HistoryDate = historyDate;
			Product = product;
			HistoryOperation = historyOperation;
			UserName = userName;
			Detail = detail;
		}

		public int CalculateQuantityDiference() => CurrentQuantity - LatestQuantity;
	}
}