using Business.Dto;
using Business.Mappers.CallMappers;
using Business.Mappers.HomeInternetMappers;
using Business.Mappers.InternetMappers;
using Business.Mappers.RoamingMappers;
using Business.Mappers.SmsMappers;
using Data.Contracts.Entities;

namespace Business.Mappers.RateMappers
{
    public static class RateDtoMapper
    {
        public static RateDto Map(Rate rate)
        {
            return new RateDto
            {
                Id = rate.Id,
                Call = CallDtoMapper.Map(rate.Call),
                Sms = SmsDtoMapper.Map(rate.Sms),
                Internet = InternetDtoMapper.Map(rate.Internet),
                Roaming = RoamingDtoMapper.Map(rate.Roaming),
                HomeInternet = HomeInternetDtoMapper.Map(rate.HomeInternet),
            };
        }
    }
}
