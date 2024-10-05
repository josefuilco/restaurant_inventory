using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Inventory.Domain.Port.Repository;

namespace Inventory.Api.Module.Inventory.Application.Service
{
    public class ProviderService : IProviderService
    {
		private readonly IProviderRepository repository;

		public ProviderService(IProviderRepository repository)
		{
			this.repository = repository;
		}

        public async Task<bool> CreateProviderAsync(Provider provider)
        {
            var isCreated = await repository.AddAsync(provider);
            if (!isCreated) throw new Exception("Provedor No Creado");
            return isCreated;
        }

        public async Task<bool> DeleteProviderAsync(int providerId)
        {
            var isDeleted = await repository.RemoveAsync(providerId);
            if (!isDeleted) throw new Exception("Provedor No Eliminado");
            return isDeleted;
        }

        public async Task<IEnumerable<ProviderDto>> GetAllProvidersAsync()
        {
            var providers = await repository.GetAllAsync();
			return from p in providers select new ProviderDto(
				p.Id,
				p.Name.Value,
				p.Cellphone.Value
			);
        }

        public async Task<bool> UpdateProviderAsync(Provider provider)
        {
            var isUpdated = await repository.UpdateAsync(provider);
            if (!isUpdated) throw new Exception("Provedor No Actualizado");
            return isUpdated;
        }
    }
}