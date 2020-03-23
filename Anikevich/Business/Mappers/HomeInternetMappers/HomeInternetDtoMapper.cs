using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.HomeInternetMappers
{
    public static class HomeInternetDtoMapper
    {
        public static HomeInternetDto Map(HomeInternet homeInternet)
        {
            return new HomeInternetDto
            {
                FeePerMegabyte = homeInternet.FeePerMegabyte,
                NumberOfMegabyte = homeInternet.NumberOfMegabyte,
                Speed = homeInternet.Speed,
            };
        }
    }
}
