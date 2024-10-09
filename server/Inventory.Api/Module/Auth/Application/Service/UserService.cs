using Inventory.Api.Module.Auth.Application.Dto;
using Inventory.Api.Module.Auth.Application.Port.Service;
using Inventory.Api.Module.Auth.Domain.Model;
using Inventory.Api.Module.Auth.Domain.Port.ExternalService;
using Inventory.Api.Module.Auth.Domain.Port.Repository;
using Inventory.Api.Module.Auth.Domain.ValueObject;

namespace Inventory.Api.Module.Auth.Application.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository repository;
		private readonly IToken token;

		public UserService(IUserRepository repository, IToken token)
		{
			this.repository = repository;
			this.token = token;
		}

		public async Task<bool> CreateUserAsync(User user)
		{
			var isCreated = await repository.AddAsync(user);
			if (!isCreated) throw new Exception("User.Not-Created");
			return isCreated;
		}
		public async Task<IEnumerable<UserDto>> GetAllAsync()
		{
			var users = await repository.GetAllAsync();
			return from user in users
			where user.IsActive == true
			select new UserDto(
				user.Id,
				user.Name.EnsureUsernameHaveSpaces(),
				user.Email.Value,
				user.CreationDate,
				user.Role
			);
		}
		public async Task<UserDto> GetByTokenAsync(string token)
		{
			var tokenData = this.token.GetData(token);
			var userId = Convert.ToInt32(tokenData["user_id"]);
			var user = await repository.FindByIdAsync(userId);
			return new(
				user.Id,
				user.Name.EnsureUsernameHaveSpaces(),
				user.Email.Value,
				user.CreationDate,
				user.Role
			);
		}
		public async Task<bool> UpdatePasswordAsync(int id, string currentPassword, string newPassword)
		{
			UserPassword currentPasswordVo = new(currentPassword);
			UserPassword newPasswordVo = new(newPassword);
			var isUpdated = await repository.ChangePasswordAsync(id,
				currentPasswordVo.EnsureEncryptPassword(),
				newPasswordVo.EnsureEncryptPassword()
			);
			if (!isUpdated) throw new Exception("User.Not-Updated");
			return isUpdated;
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var isDeleted = await repository.RemoveAsync(id);
			if (!isDeleted) throw new Exception("User.Not-Deleted");
			return isDeleted;
		}
	}
}