namespace Inventory.Api.Module.Inventory.Domain.ValueObject
{
	public class ProductQuantity(int value)
    {
        public int Value { get; } = EnsureProductQuantity(value);

        private static int EnsureProductQuantity(int value)
		{
			if (value < 0) throw new Exception("Product-Quantity.Invalid");
			return value;
		}
	}
}