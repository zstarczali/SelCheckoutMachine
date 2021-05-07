
using AutoMapper;

using SelfCheckoutMachine.AutoMapping.Interfaces;
using SelfCheckoutMachine.Services.Models;

namespace SelfCheckoutMachine.Models
{
    public class StockDataModel : IHaveCustomMapping
    {
        public InsertedModel Inserted { get; set; }
        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<StockDataModel, StockServiceModel>()
                .ForMember(dest => dest.Five, opt => opt.MapFrom(src => src.Inserted.Five))
                .ForMember(dest => dest.Ten, opt => opt.MapFrom(src => src.Inserted.Ten))
                .ForMember(dest => dest.Twenty, opt => opt.MapFrom(src => src.Inserted.Twenty))
                .ForMember(dest => dest.Fifty, opt => opt.MapFrom(src => src.Inserted.Fifty))
                .ForMember(dest => dest.Hundred, opt => opt.MapFrom(src => src.Inserted.Hundred))
                .ForMember(dest => dest.TwoHundred, opt => opt.MapFrom(src => src.Inserted.TwoHundred))
                .ForMember(dest => dest.FiveHundred, opt => opt.MapFrom(src => src.Inserted.FiveHundred));
            ;
        }
    }
}
