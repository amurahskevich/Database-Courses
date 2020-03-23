using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.CallMappers
{
    public static class CallMapper
    {
        public static Call Map(CallDto dto)
        {
            return new Call
            {
                NumberOfMinutes = dto.NumberOfMinutes,
                FeePerMinute = dto.FeePerMinute,
            };
        }
    }
}
