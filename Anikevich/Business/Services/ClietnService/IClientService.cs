using Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ClietnService
{
    public interface IClientService
    {
        Task<ClientDto> GettById(int id);

        Task<IReadOnlyCollection<ClientDto>> GetAll();

        Task<ClientDto> Create(ClientDto dto);

        Task<ClientDto> Update(ClientDto dto);

        Task Remove(int id);
    }
}
