using System.Threading.Tasks;
using SelfCheckoutMachine.Models;
using SelfCheckoutMachine.Services.Models;

namespace SelfCheckoutMachine.Services.Checkout
{
    public interface ICheckoutService
    {
        Task<StockCashDto> CheckoutAsync<T>(T model)
        where T : CheckoutServiceModel;
    }
}
