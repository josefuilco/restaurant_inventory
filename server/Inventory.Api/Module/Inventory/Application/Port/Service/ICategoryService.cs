using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Api.Module.Inventory.Application.Dto;

namespace Inventory.Api.Module.Inventory.Application.Port.Service
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
    }
}