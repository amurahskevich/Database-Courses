using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.RoamingMappers
{
    public static class RoamingDtoMapper
    {
        public static RoamingDto Map(Roaming roaming)
        {
            return new RoamingDto
            {
                FeePerMinute = roaming.FeePerMinute,
                NumberOfMinutes = roaming.NumberOfMinutes,
            };
        }
    }
}
