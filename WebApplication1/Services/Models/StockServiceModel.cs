using SelfCheckoutMachine.AutoMapping.Interfaces;
using SelfCheckoutMachine.Models;

namespace SelfCheckoutMachine.Services.Models
{
    public class CheckoutServiceModel :  IMapWith<CheckoutDataModel>
    {
        public int FiveHundred { get; set; }

        public int TwoHundred { get; set; }

        public int Hundred { get; set; }

        public int Ten { get; set; }

        public int Twenty { get; set; }

        public int Five { get; set; }

        public int Fifty { get; set; }

        public int Price { get; set; }
    }
}
