namespace Inventory.Api.Module.History.Domain.Model
{
    public class ProductInfo
    {
        public int Id { get; }
        public string Name { get; }

        public ProductInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}