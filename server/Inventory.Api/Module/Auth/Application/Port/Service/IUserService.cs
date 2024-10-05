using Inventory.Api.Module.Auth.Application.Dto;
using Inventory.Api.Module.Auth.Domain.Model;

namespace Inventory.Api.Module.Auth.Application.Port.Service
{
	public interface IUserService
	{
		Task<bool> CreateUserAsync(User user);
		Task<IEnumerable<UserDto>> GetAllAsync();
		Task<UserDto> GetByTokenAsync(string token);
		Task<bool> UpdatePasswordAsync(int id, string currentPassword, string newPassword);
		Task<bool> DeleteAsync(int id);
	}
}