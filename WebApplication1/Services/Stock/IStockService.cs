using SelfCheckoutMachine.Models;

using System.Threading.Tasks;
using SelfCheckoutMachine.Services.Models;

namespace SelfCheckoutMachine.Services.Stock
{
    public interface IStockService
    {
        public Task<bool> StockAsync<T>(T model)
        where T : StockServiceModel;
        public Task<bool> AddOrUpdate(string cashTypeId, int amount);
        public StockCashDto GetStocks();
    }
}
