using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.RoamingMappers
{
    public static class RoamingMapper
    {
        public static Roaming Map(RoamingDto dto)
        {
            return new Roaming
            {
                NumberOfMinutes = dto.NumberOfMinutes,
                FeePerMinute = dto.FeePerMinute,
            };
        }
    }
}
