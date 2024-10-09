using Inventory.Api.Module.Auth.Domain.Enums;

namespace Inventory.Api.Module.Auth.Application.Dto
{
	public record UserDto(
		int Id,
		string Name,
		string Email,
		DateTime CreationDate,
		UserRole Role
	);
}