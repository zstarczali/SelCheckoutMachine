using Microsoft.Extensions.Logging;

using SelfCheckoutMachine.Data;
using SelfCheckoutMachine.Models;
using SelfCheckoutMachine.Services.Models;
using SelfCheckoutMachine.Services.Stock;

using System.Threading.Tasks;

namespace SelfCheckoutMachine.Services.Checkout
{
    public class CheckoutService : ICheckoutService
    {
        private readonly CashDbContext dbContext;
        private readonly ILogger<StockService> logger;

        public CheckoutService(ILogger<StockService> logger,
            CashDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<StockCashDto> CheckoutAsync<T>(T model) where T : CheckoutServiceModel
        {

            var totalIncome = Calculate(model);

            if (model.Price > totalIncome)
                return null;

            var leftoverMoney = totalIncome - model.Price;

            var leftover = Change(leftoverMoney);

            // udate db ans so on



            return leftover;
        }


        private int Calculate(CheckoutServiceModel model)
        {
            int price = 0;
            price += model.Five * 5;
            price += model.Ten * 10;
            price += model.Twenty * 20;
            price += model.Fifty * 50;
            price += model.Hundred * 100;
            price += model.TwoHundred * 200;
            price += model.FiveHundred * 500;


            return price;
        }

        public StockCashDto Change(decimal price)
        {
            StockCashDto stockCashDto = new StockCashDto();

            stockCashDto.FiveHundred = (int)(price / 500);
            price %= 500;

            stockCashDto.TwoHundred = (int)(price / 200);
            price %= 200;

            stockCashDto.Hundred = (int)(price / 100);
            price %= 100;

            stockCashDto.Fifty = (int)(price / 50);
            price %= 50;

            stockCashDto.Twenty = (int)(price / 20);
            price %= 20;

            stockCashDto.Ten = (int)(price / 10);
            price %= 10;

            stockCashDto.Five = (int)(price / 5);
            price %= 5;

            return stockCashDto;
        }

    }
}
