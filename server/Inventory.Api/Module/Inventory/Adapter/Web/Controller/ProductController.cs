using Inventory.Api.Module.Inventory.Adapter.Web.Request;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Domain.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.Inventory.Adapter.Web.Controller
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IUnitMeasureService measureService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ICategoryService categoryService, IUnitMeasureService measureService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.measureService = measureService;
            this.logger = logger;
        }

        #region Endpoints
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ProductList()
        {
            try
            {
                var products = await productService.GetAllProductsAsync();
                var response = new{
                    message = "Productos Encontrados",
                    data = products
                };
                logger.LogInformation("Productos: {products}", products);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult CategoryList()
        {
            try
            {
                var categories = categoryService.GetAllCategories();
                var response = new{
                    message = "Categorias Encontrados",
                    data = categories
                };
                logger.LogInformation("Categorias: {categories}", categories);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        [Route("unit-measures")]
        public IActionResult UnitMeasureList()
        {
            try
            {
                var measures = measureService.GetAllUnitMeasures();
                var response = new{
                    message = "Medidas Encontrados",
                    data = measures
                };
                logger.LogInformation("Medidas: {measures}", measures);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var builder = new ProductBuilder();
            try
            {
                var isCreated = await productService.CreateProductAsync(builder
                .AddName(request.Name)
                .AddPrice(request.Price)
                .AddQuantity(request.Quantity)
                .AddMinimalQuantity(request.MinimalQuantity)
                .AddProductProviderId(request.ProviderId)
                .AddCategory((short)request.CategoryId)
                .Build(), request.UserId);
                var response = new{
                    message = "Producto Creado",
                    data = isCreated
                };
                logger.LogInformation("Producto: {request.Name}", request.Name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var builder = new ProductBuilder();
            try
            {
                var isUpdated = await productService.UpdateProductAsync(builder
                .AddId(request.Id)
                .AddName(request.Name)
                .AddPrice(request.Price)
                .AddQuantity(request.Quantity)
                .AddMinimalQuantity(request.MinimalQuantity)
                .AddProductProviderId(request.ProviderId)
                .AddCategory((short)request.CategoryId)
                .Build(), request.UserId);
                var response = new{
                    message = "Producto Actualizado",
                    data = isUpdated
                };
                logger.LogInformation("Producto: {request.Name}", request.Name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut]
        [Route("update-stock")]
        public async Task<IActionResult> UpdateProductStock([FromBody] UpdateStockRequest request)
        {
            try
            {
                var isUpdated = await productService.UpdateStockProductAsync(request.Id, request.Quantity, request.UserId);
                var response = new{
                    message = "Producto Actualizado",
                    data = isUpdated
                };
                logger.LogInformation("Nueva Cantidad: {request.Quantity}", request.Quantity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut]
        [Route("remove")]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductRequest request)
        {
            try
            {
                var isRemoved = await productService.DeleteProductAsync(request.ProductId, request.UserId);
                var response = new{
                    message = "Producto Borrado",
                    data = isRemoved
                };
                logger.LogInformation("Product Id: {request.ProductId}", request.ProductId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new{
                    message = ex.Message,
                    data = false
                };
                logger.LogError("Failed in {ex.Message}", ex.Message);
                return StatusCode(500, response);
            }
        }
        #endregion
    }
}