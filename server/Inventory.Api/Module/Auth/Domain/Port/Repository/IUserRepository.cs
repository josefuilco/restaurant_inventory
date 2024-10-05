using Inventory.Api.Module.Auth.Domain.Model;

namespace Inventory.Api.Module.Auth.Domain.Port.Repository
{
	public interface IUserRepository
	{
		Task<bool> AddAsync(User user);
		Task<int> FindIdByAuthAsync(string username, string password);
		Task<User> FindByIdAsync(int id);
		Task<IEnumerable<User>> GetAllAsync();
		Task<bool> ChangePasswordAsync(int id, string currentPassword, string newPassword);
		Task<bool> RemoveAsync(int id);
	}
}