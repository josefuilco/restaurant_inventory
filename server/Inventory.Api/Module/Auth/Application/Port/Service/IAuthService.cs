namespace Inventory.Api.Module.Auth.Application.Port.Service
{
	public interface IAuthService
	{
		Task<string> AuthenticateUserAsync(string username, string password);
	}
}