using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Moq;

using SelfCheckoutMachine.Data;
using SelfCheckoutMachine.Models;

using System;

using TestProject1.Setup;

namespace TestProject1
{
    public abstract class BaseTest
    {

        protected BaseTest()
            => this.Mapper = TestSetup.InitializeMapper();

        protected IMapper Mapper { get; }

        protected CashDbContext DatabaseInstance
        {
            get
            {
                var options = new DbContextOptionsBuilder<CashDbContext>()
                    
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging()
                    .Options;

                return new CashDbContext(options);
            }
        }

        protected Mock<IOptions<Cash>> MockedBankConfiguration
        {
            get
            {
                var configuration = new Cash
                {

                };

                var options = new Mock<IOptions<Cash>>();
                options.Setup(x => x.Value).Returns(configuration);

                return options;
            }
        }
    }
}