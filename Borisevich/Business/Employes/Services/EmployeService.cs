using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Employe;

namespace Business.Employes.Services
{
    public class EmployeService : IEmployeService
    {
        public Task<EmployeDto> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<EmployeDto>> GetList()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(EmployeDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(EmployeDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
