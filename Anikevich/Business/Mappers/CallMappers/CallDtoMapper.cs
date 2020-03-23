using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.CallMappers
{
    public static class CallDtoMapper
    {
        public static CallDto Map(Call call)
        {
            return new CallDto
            {
                FeePerMinute = call.FeePerMinute,
                NumberOfMinutes = call.NumberOfMinutes,
            };
        }
    }
}
