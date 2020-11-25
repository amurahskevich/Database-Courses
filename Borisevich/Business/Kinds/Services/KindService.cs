using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Kind;

namespace Business.Kinds.Services
{
    public class KindService : IKindService
    {
        public Task<KindDto> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<KindDto>> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(KindDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(KindDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
