using AutoMapper;

namespace SelfCheckoutMachine.AutoMapping.Interfaces
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}