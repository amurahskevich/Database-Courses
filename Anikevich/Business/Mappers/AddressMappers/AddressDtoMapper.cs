using Business.Dto;
using Data.Contracts.Entities;

namespace Business.Mappers.AddressMappers
{
    public static class AddressDtoMapper
    {
        public static AddressDto Map(Address address)
        {
            return new AddressDto
            {
                City = address.City,
                Street = address.Street,
            };
        }
    }
}
