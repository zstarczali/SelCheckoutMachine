using Microsoft.Extensions.Logging;

using SelfCheckoutMachine.Constants;
using SelfCheckoutMachine.Data;
using SelfCheckoutMachine.Models;

using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using SelfCheckoutMachine.Services.Models;

namespace SelfCheckoutMachine.Services.Stock
{
    public class StockService : IStockService
    {
        private readonly CashDbContext dbContext;
        private readonly ILogger<StockService> logger;

        public StockService(CashDbContext dbContext,
            ILogger<StockService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<bool> StockAsync<T>(T model) where T : StockServiceModel
        {
            try
            {
                if (model.Five != 0) { await AddOrUpdate(CashTypes.Five, amount: model.Five); }
                if (model.Ten != 0) { await AddOrUpdate(CashTypes.Ten, amount: model.Ten); }
                if (model.Twenty != 0) { await AddOrUpdate(CashTypes.Twenty, amount: model.Twenty); }
                if (model.Fifty != 0) { await AddOrUpdate(CashTypes.Fifty, amount: model.Fifty); }
                if (model.Hundred != 0) { await AddOrUpdate(CashTypes.Hundred, amount: model.Hundred); }
                if (model.TwoHundred != 0) { await AddOrUpdate(CashTypes.TwoHundred, amount: model.TwoHundred); }
                if (model.FiveHundred != 0) { await AddOrUpdate(CashTypes.FiveHundred, amount: model.FiveHundred); }
                logger.LogInformation("StockAsync done!");
            }
            catch (DbException ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
                return false;
            }

            return true;
        }

        public async Task<bool> AddOrUpdate(string cashTypeId, int amount)
        {
            var result = dbContext.CashSet.SingleOrDefault(b => b.CashTypeId == cashTypeId);
            if (result != null)
            {
                result.Amount += amount;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                await dbContext.CashSet.AddAsync(new Cash()
                { Amount = amount, CashTypeId = cashTypeId, LastUpdated = DateTime.Now });
                await dbContext.SaveChangesAsync();
            }

            return true;
        }

        public StockCashDto GetStocks()
        {
            StockCashDto imCashDto = new StockCashDto();
            var items = dbContext.CashSet.Select(n => new { CashTypeId = n.CashTypeId, Amount = n.Amount }).ToList();

            imCashDto.Five = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.Five)?.Amount;
            imCashDto.Ten = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.Ten)?.Amount;
            imCashDto.Fifty = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.Twenty)?.Amount;
            imCashDto.Twenty = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.Fifty)?.Amount;
            imCashDto.Hundred = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.Hundred)?.Amount;
            imCashDto.TwoHundred = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.TwoHundred)?.Amount;
            imCashDto.FiveHundred = items.Select(n => n).ToList().FirstOrDefault(n => n.CashTypeId == CashTypes.FiveHundred)?.Amount;

            return imCashDto;
        }
    }
}
