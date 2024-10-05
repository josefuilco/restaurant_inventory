using Inventory.Api.Module.Inventory.Domain.Enums;
using Inventory.Api.Module.Inventory.Domain.Model;

namespace Inventory.Api.Module.Inventory.Domain.Builder
{
    public class ProductBuilder
    {
        private int id = 0;
        private string name = string.Empty;
        private decimal price = 0m;
        private int quantity = 0;
        private int minimalQuantity = 0;
        private bool isActive = true;
        private int providerId = 1;
        private string providerName = "base-name";
        private short category = 1;
        private short measure = 1;

        #region Methods
        private void Reset()
        {
            id = 0;
            name = string.Empty;
            price = 0m;
            quantity = 0;
            minimalQuantity = 0;
            isActive = true;
            providerId = 1;
            providerName = "base-name";
            category = 1;
            measure = 1;
        }

        public ProductBuilder AddId(int id)
        {
            this.id = id;
            return this;
        }

        public ProductBuilder AddName(string name)
        {
            this.name = name;
            return this;
        }

        public ProductBuilder AddPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public ProductBuilder AddQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public ProductBuilder AddMinimalQuantity(int minimalQuantity)
        {
            this.minimalQuantity = minimalQuantity;
            return this;
        }

        public ProductBuilder AddIsActive(bool isActive)
        {
            this.isActive = isActive;
            return this;
        }

        public ProductBuilder AddProductProviderId(int providerId)
        {
            this.providerId = providerId;
            return this;
        }

        public ProductBuilder AddProductProviderName(string providerName)
        {
            this.providerName = providerName;
            return this;
        }

        public ProductBuilder AddCategory(short category)
        {
            this.category = category;
            return this;
        }

        public ProductBuilder AddMeasure(short measure)
        {
            this.measure = measure;
            return this;
        }

        public Product Build()
        {
            Product product = new(
                id,
                new(name),
                new(price),
                new(quantity),
                new(minimalQuantity),
                isActive,
                new(
					providerId,
					new(providerName),
					new("000000000"),
					true
				),
                (ProductCategory)category,
                (UnitMeasure)measure
            );
            Reset();
            return product;
        }
        #endregion
    }
}
