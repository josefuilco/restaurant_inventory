using Inventory.Api.Module.Auth.Application.Port.Service;
using Inventory.Api.Module.Auth.Domain.Port.ExternalService;
using Inventory.Api.Module.Auth.Domain.Port.Repository;
using Inventory.Api.Module.Auth.Domain.ValueObject;

namespace Inventory.Api.Module.Auth.Application.Service
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository repository;
		private readonly IToken token;

		public AuthService(IUserRepository repository, IToken token)
		{
			this.repository = repository;
			this.token = token;
		}

		public async Task<string> AuthenticateUserAsync(string username, string password)
		{
			UserName usernameVo = new(username);
			UserPassword passwordVo = new(password);
			var id = await repository.FindIdByAuthAsync(
				usernameVo.EnsureUsernameHaventSpaces(),
				passwordVo.EnsureEncryptPassword()
			);
			if (id == 0) throw new Exception("Authenticate.Failed");
			return token.CreateToken(id);
		}
	}
}