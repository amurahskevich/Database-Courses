using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.AddressMappers
{
    public static class AddressMapper
    {
        public static Address Map(AddressDto dto)
        {
            return new Address
            {
                City = dto.City,
                Street = dto.Street,
            };
        }
    }
}
