using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SelfCheckoutMachine.Models;
using SelfCheckoutMachine.Services.Models;
using SelfCheckoutMachine.Services.Stock;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutMachine.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> logger;
        private readonly IStockService stockService;
        private readonly IMapper mapper;

        public StockController(
            ILogger<StockController> logger,
            IMapper mapper,
            IStockService stockService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.stockService = stockService;
        }

        [HttpGet]
        public async Task<StockCashDto> Index()
        {
            logger.LogInformation($"Index[GET] - Get stock");

            var stockCashDto = stockService.GetStocks();

            return stockCashDto;
        }

        [HttpPost]
        public async Task<IEnumerable<StockServiceModel>> Create(StockDataModel model)
        {
            logger.LogInformation($"Create[POST] - Add stock : ${model.Inserted.GetType()}");

            var serviceModel = mapper.Map<StockServiceModel>(model);
            await stockService.StockAsync(serviceModel);

            return Enumerable.Empty<StockServiceModel>();
        }
    }
}
