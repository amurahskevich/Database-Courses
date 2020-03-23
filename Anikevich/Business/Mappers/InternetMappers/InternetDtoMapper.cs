using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.InternetMappers
{
    public static class InternetDtoMapper
    {
        public static InternetDto Map(Internet internet)
        {
            return new InternetDto
            {
                FeePerMegabyte = internet.FeePerMegabyte,
                NumberOfMegabyte = internet.NumberOfMegabyte,
                Speed = internet.Speed,
            };
        }
    }
}
