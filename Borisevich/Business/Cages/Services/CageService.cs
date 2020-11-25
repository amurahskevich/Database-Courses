using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Cage;

namespace Business.Cages.Services
{
    public class CageService : ICageService
    {
        public Task<CageDto> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<CageDto>> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(CageDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CageDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
