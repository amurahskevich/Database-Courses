using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.HomeInternetMappers
{
    public static class HomeInternetMapper
    {
        public static HomeInternet Map(HomeInternetDto dto)
        {
            return new HomeInternet
            {
                Speed = dto.Speed,
                NumberOfMegabyte = dto.NumberOfMegabyte,
                FeePerMegabyte = dto.FeePerMegabyte,
            };
        }
    }
}
