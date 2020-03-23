using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.SmsMappers
{
    public static class SmsMapper
    {
        public static Sms Map(SmsDto dto)
        {
            return new Sms
            {
                NumberOfSms = dto.NumberOfSms,
                FeePerSms = dto.FeePerSms,
            };
        }
    }
}
