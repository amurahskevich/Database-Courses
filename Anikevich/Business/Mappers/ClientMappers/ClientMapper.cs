using Business.Dto;
using Business.Mappers.AddressMappers;
using Data.Contracts.Entities;

namespace Business.Mappers.ClientMappers
{
    public static class ClientMapper
    {
        public static Client Map(ClientDto dto)
        {
            return new Client
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Address = AddressMapper.Map(dto.Address),
                RateId = dto.RateId != 0
                ? dto.RateId
                : default,
            };
        }

        public static void MapUpdate(Client client, ClientDto dto)
        {
            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Age = dto.Age;
            client.Address = AddressMapper.Map(dto.Address);
            client.RateId = dto.RateId;
        }
    }
}
