using Business.Dto;
using Business.Mappers.AddressMappers;
using Data.Contracts.Entities;

namespace Business.Mappers.ClientMappers
{
    public static class ClientDtoMapper
    {
        public static ClientDto Map(Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Age = client.Age,
                Address = client.Address != null
                    ? AddressDtoMapper.Map(client.Address)
                    : new AddressDto(),
            };
        }
    }
}
