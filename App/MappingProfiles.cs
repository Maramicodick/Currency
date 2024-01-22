using AutoMapper;
using Domain.DbModels;
using Domain.Deserialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CurrencyExchangeRate, LiveCurrency>()
                .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.ExchangeRateValue))
                .ForMember(dest => dest.LastRefreshed, opt => opt.MapFrom(src => src.LastRefreshed))
                .ForMember(dest => dest.FromCurrencyCode, opt => opt.MapFrom(src => src.FromCurrencyCode))
                .ForMember(dest => dest.ToCurrencyCode, opt => opt.MapFrom(src => src.ToCurrencyCode))
                .ForMember(dest => dest.AskPrice, opt => opt.MapFrom(src => src.AskPrice))
                .ForMember(dest => dest.BidPrice, opt => opt.MapFrom(src => src.BidPrice));
        }
    }
}
