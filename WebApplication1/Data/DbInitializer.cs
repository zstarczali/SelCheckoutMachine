using SelfCheckoutMachine.Constants;
using SelfCheckoutMachine.Models;

using System;
using System.Linq;

namespace SelfCheckoutMachine.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CashDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CashSet.Any())
            {
                return;   // DB has been seeded
            }

            var Defaults = new Cash[]
            {
                new Cash{CashTypeId= CashTypes.Five,Amount = 10,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.Ten,Amount = 10,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.Twenty,Amount = 10,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.Fifty,Amount = 5,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.Hundred,Amount = 5,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.TwoHundred,Amount = 5,LastUpdated= DateTime.UtcNow},
                new Cash{CashTypeId= CashTypes.FiveHundred,Amount = 5,LastUpdated= DateTime.UtcNow},

            };
            foreach (Cash s in Defaults)
            {
                context.CashSet.Add(s);
            }
            context.SaveChanges();

        }
    }
}