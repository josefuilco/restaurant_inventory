namespace Inventory.Api.Module.Inventory.Domain.ValueObject
{
	public class ProductPrice(decimal price)
	{
		public decimal Value { get; } = EnsureProductPrice(price);

		private static decimal EnsureProductPrice(decimal price)
		{
			if (price < 0) throw new Exception("Product-Price.Invalid");
			return price;
		}
	}
}