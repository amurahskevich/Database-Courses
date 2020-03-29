using Business.Dto;
using Business.Mappers.CallMappers;
using Business.Mappers.HomeInternetMappers;
using Business.Mappers.InternetMappers;
using Business.Mappers.RoamingMappers;
using Business.Mappers.SmsMappers;
using Data.Contracts.Entities;

namespace Business.Mappers.RateMappers
{
    public static class RateMapper
    {
        public static Rate Map(RateDto dto)
        {
            return new Rate
            {
                Id = dto.Id,
                Name = dto.Name,
                Call = CallMapper.Map(dto.Call),
                Sms = SmsMapper.Map(dto.Sms),
                Internet = InternetMapper.Map(dto.Internet),
                Roaming = RoamingMapper.Map(dto.Roaming),
                HomeInternet = HomeInternetMapper.Map(dto.HomeInternet),
            };
        }

        public static void MapUpdate(Rate rate, RateDto dto)
        {
            rate.Name = dto.Name;
            rate.Call = CallMapper.Map(dto.Call);
            rate.Sms = SmsMapper.Map(dto.Sms);
            rate.Internet = InternetMapper.Map(dto.Internet);
            rate.Roaming = RoamingMapper.Map(dto.Roaming);
            rate.HomeInternet = HomeInternetMapper.Map(dto.HomeInternet);
        }
    }
}
