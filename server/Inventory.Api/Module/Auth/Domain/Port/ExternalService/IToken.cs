namespace Inventory.Api.Module.Auth.Domain.Port.ExternalService
{
	public interface IToken
	{
		string CreateToken(int id);
		Dictionary<string, int> GetData(string token);
	}
}