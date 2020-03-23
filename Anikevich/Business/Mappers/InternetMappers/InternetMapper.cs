using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.InternetMappers
{
    public static class InternetMapper
    {
        public static Internet Map(InternetDto dto)
        {
            return new Internet
            {
                Speed = dto.Speed,
                NumberOfMegabyte = dto.NumberOfMegabyte,
                FeePerMegabyte = dto.FeePerMegabyte,
            };
        }
    }
}
