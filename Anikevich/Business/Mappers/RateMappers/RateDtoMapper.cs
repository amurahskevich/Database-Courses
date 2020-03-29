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
                Name = rate.Name,
                Call = rate.Call != null 
                    ? CallDtoMapper.Map(rate.Call)
                    : new CallDto(),
                Sms = rate.Sms != null 
                    ? SmsDtoMapper.Map(rate.Sms)
                    : new SmsDto(),
                Internet = rate.Internet != null
                    ? InternetDtoMapper.Map(rate.Internet)
                    : new InternetDto(),
                Roaming = rate.Roaming != null
                    ? RoamingDtoMapper.Map(rate.Roaming)
                    : new RoamingDto(),
                HomeInternet = rate.HomeInternet != null
                    ? HomeInternetDtoMapper.Map(rate.HomeInternet)
                    : new HomeInternetDto(),
            };
        }
    }
}
