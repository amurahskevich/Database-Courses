using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.SmsMappers
{
    public static class SmsDtoMapper
    {
        public static SmsDto Map(Sms sms)
        {
            return new SmsDto
            {
                FeePerSms = sms.FeePerSms,
                NumberOfSms = sms.NumberOfSms,
            };
        }
    }
}
