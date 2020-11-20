using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Department;

namespace Business.Departments.Services
{
    public interface IDepartmentService
    {
        Task<IReadOnlyCollection<DepartmentDto>> GetList();

        Task<DepartmentDto> Get(int id);

        Task Create(DepartmentDto department);

        Task Update(DepartmentDto department);

        Task Delete(int id);
    }
}
