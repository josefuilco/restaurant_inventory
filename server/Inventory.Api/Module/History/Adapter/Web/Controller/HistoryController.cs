using Inventory.Api.Module.History.Adapter.Web.Request;
using Inventory.Api.Module.History.Application.Port.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Module.History.Adapter.Web.Controller
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService historyService;
        private readonly IOperationService operationService;
        private readonly ILogger<HistoryController> logger;

        public HistoryController(IHistoryService historyService, IOperationService operationService, ILogger<HistoryController> logger)
        {
            this.historyService = historyService;
            this.operationService = operationService;
            this.logger = logger;
        }

        #region Endpoints
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> ListHistories([FromBody] HistoryRequest requestBody)
        {
            try
            {
                var histories = await historyService.GetHistoriesAsync(requestBody.ProductId, requestBody.From, requestBody.To);
                var response = new{
                    message = "Histories Found",
                    data = histories
                };
                logger.LogInformation("Histories between {requestBody.From} and {requestBody.To}", requestBody.From, requestBody.To);
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
        [Route("operations")]
        public IActionResult ListOperations()
        {
            try
            {
                var operations = operationService.GetOperations();
                var response = new{
                    message = "Histories Found",
                    data = operations
                };
                logger.LogInformation("The Operations are {operations}", operations);
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