using Inventory.Api.Module.Inventory.Domain.Enums;
using Inventory.Api.Module.Inventory.Domain.ValueObject;

namespace Inventory.Api.Module.Inventory.Domain.Model
{
	public class Product(
		int id,
		ProductName name,
		ProductPrice price,
		ProductQuantity quantity,
		ProductQuantity minimalQuantity,
		bool isActive,
		Provider productProvider,
		ProductCategory category,
		UnitMeasure measure
	)
	{
		public int Id { get; set; } = id;
		public ProductName Name { get; set; } = name;
		public ProductPrice Price { get; set; } = price;
		public ProductQuantity Quantity { get; set; } = quantity;
		public ProductQuantity MinimalQuantity { get; set; } = minimalQuantity;
		public bool IsActive { get; set; } = isActive;
		public Provider ProductProvider { get; set; } = productProvider;
		public ProductCategory Category { get; set; } = category;
		public UnitMeasure Measure { get; set; } = measure;
	}
}