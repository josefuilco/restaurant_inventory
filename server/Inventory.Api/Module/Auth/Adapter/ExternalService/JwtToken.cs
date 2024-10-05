using Inventory.Api.Module.Auth.Domain.Port.ExternalService;
using JWT.Algorithms;
using JWT.Builder;

namespace Inventory.Api.Module.Auth.Adapter.ExternalService
{
	public class JwtToken : IToken
	{
		private readonly string secret;
		private readonly HMACSHA256Algorithm algorithm;

		public JwtToken(IConfiguration config)
		{
			secret = config.GetValue<string>("Secret.Jwt")!;
			algorithm = new();
		}
		public string CreateToken(int id)
		{
			return JwtBuilder.Create()
			.WithAlgorithm(algorithm)
			.WithSecret(secret)
			.MustVerifySignature()
			.AddClaim("exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds())
			.AddClaim("user_id", id)
			.Encode();
		}
		public Dictionary<string, int> GetData(string token)
		{
			return JwtBuilder.Create()
			.WithAlgorithm(algorithm)
			.WithSecret(secret)
			.MustVerifySignature()
			.Decode<Dictionary<string, int>>(token);
		}
	}
}