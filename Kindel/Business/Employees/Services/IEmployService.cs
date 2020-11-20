using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Employe;

namespace Business.Employees.Services
{
    public interface IEmployService
    {
        Task<IReadOnlyCollection<EmployeDto>> GetList();

        Task<IReadOnlyCollection<EmployeDto>> GetListByCategory(int categoryId);

        Task<IReadOnlyCollection<EmployeDto>> GetListByDepartment(int departmentId);

        Task<IReadOnlyCollection<EmployeDto>> GetByProject(int projectId);

        Task<IReadOnlyCollection<EmployeDto>> GetDepartmentHeads();

        Task<EmployeDto> Get(int id);

        Task Create(EmployeDto employe);

        Task Update(EmployeDto employe);

        Task Delete(int id);
    }
}
