using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SelfCheckoutMachine.Data;
using SelfCheckoutMachine.Models;
using SelfCheckoutMachine.Services.Checkout;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfCheckoutMachine.Services.Models;

namespace SelfCheckoutMachine.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> logger;
        private readonly ICheckoutService checkoutService;
        private readonly IMapper mapper;


        /// <inheritdoc />
        public CheckoutController(
            ILogger<CheckoutController> logger,
            IMapper mapper,
            ICheckoutService checkoutService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.checkoutService = checkoutService;
        }



        [HttpPost]
        public async Task<StockCashDto> Create(CheckoutDataModel model)
        {
            logger.LogInformation("Create[POST] - Checkout");

            var serviceModel = mapper.Map<CheckoutServiceModel>(model);
            var leftover = await checkoutService.CheckoutAsync(serviceModel);

            return leftover;
        }
    }
}
