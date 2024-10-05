using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Domain.Model;

namespace Inventory.Api.Module.Inventory.Application.Port.Service
{
	public interface IProviderService
	{
		Task<bool> CreateProviderAsync(Provider provider);
        Task<IEnumerable<ProviderDto>> GetAllProvidersAsync();
        Task<bool> UpdateProviderAsync(Provider provider);
        Task<bool> DeleteProviderAsync(int providerId);
	}
}