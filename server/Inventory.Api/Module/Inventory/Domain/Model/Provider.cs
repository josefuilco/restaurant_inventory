using Inventory.Api.Module.Inventory.Domain.ValueObject;

namespace Inventory.Api.Module.Inventory.Domain.Model
{
	public class Provider(
		int id,
		ProviderName name,
		ProviderCellphone cellphone,
		bool isActive
	)
	{
		public int Id { get; set; } = id;
		public ProviderName Name { get; set; } = name;
		public ProviderCellphone Cellphone { get; set; } = cellphone;
		public bool IsActive { get; set; } = isActive;
	}
}