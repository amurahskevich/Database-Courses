using Business.Dto;
using Business.Mappers.ClientMappers;
using Data.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Business.Services.ClietnService
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext dbContext;

        public ClientService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ClientDto> Create(ClientDto dto)
        {
            var client = ClientMapper.Map(dto);
            await this.dbContext.Clients.AddAsync(client);
            await this.dbContext.SaveChangesAsync();

            return ClientDtoMapper.Map(client);
        }

        public async Task<IReadOnlyCollection<ClientDto>> GetAll()
        {
            var clients = await this.dbContext.Clients.ToListAsync();

            return clients
                .Select(ClientDtoMapper.Map)
                .ToArray();
        }

        public async Task<ClientDto> GettById(int id)
        {
            var client = await dbContext.Clients.FindAsync(id);

            return ClientDtoMapper.Map(client);
        }

        public async Task Remove(int id)
        {
            var client = await dbContext.Clients.FindAsync(id);
            this.dbContext.Clients.Remove(client);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ClientDto> Update(ClientDto dto)
        {
            var client = await dbContext.Clients.FindAsync(dto.Id);
            ClientMapper.MapUpdate(client, dto);
            await dbContext.SaveChangesAsync();

            return ClientDtoMapper.Map(client);
        }
    }
}
