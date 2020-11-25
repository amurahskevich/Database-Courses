using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Position;

namespace Business.Positions.Services
{
    public class PositionService : IPositionService
    {
        public Task<PositionDto> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<PositionDto>> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(PositionDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(PositionDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
