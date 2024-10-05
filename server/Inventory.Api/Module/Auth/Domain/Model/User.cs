using Inventory.Api.Module.Auth.Domain.Enums;
using Inventory.Api.Module.Auth.Domain.ValueObject;

namespace Inventory.Api.Module.Auth.Domain.Model
{
    public class User
    {
        public int Id { get; }
        public UserName Name { get; }
        public UserPassword Password { get; }
        public UserEmail Email { get; }
        public DateTime CreationDate { get; }
        public bool IsActive { get; }
        public UserRole Role { get; }

        public User(int id, UserName name, UserPassword password, UserEmail email, DateTime creationDate, bool isActive, UserRole role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            CreationDate = creationDate;
            IsActive = isActive;
            Role = role;
        }
    }
}