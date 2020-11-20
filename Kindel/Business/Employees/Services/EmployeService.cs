using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Employees.Mapping;
using Contracts.Employe;
using Domain;

namespace Business.Employees.Services
{
    public class EmployeService : IEmployService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetList()
        {
            var employees = await this.unitOfWork.EmployRepository.GetList();

            return employees.Select(EmployMapper.Map).ToArray();
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetListByCategory(int categoryId)
        {
            var employees = await this.unitOfWork.EmployRepository.GetListByCategory(categoryId);

            return employees.Select(EmployMapper.Map).ToArray();
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetListByDepartment(int departmentId)
        {
            var employees = await this.unitOfWork.EmployRepository.GetListByDepartment(departmentId);

            return employees.Select(EmployMapper.Map).ToArray();
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetByProject(int projectId)
        {
            var employees = await this.unitOfWork.EmployRepository.GetByProject(projectId);

            return employees.Select(EmployMapper.Map).ToArray();
        }

        public async Task<IReadOnlyCollection<EmployeDto>> GetDepartmentHeads()
        {
            var employees = await this.unitOfWork.EmployRepository.GetDepartmentHeads();

            return employees.Select(EmployMapper.Map).ToArray();
        }

        public async Task<EmployeDto> Get(int id)
        {
            var employe = await this.unitOfWork.EmployRepository.Get(id);

            return EmployMapper.Map(employe);
        }

        public async Task Create(EmployeDto employe)
        {
            var result = EmployMapper.MapCreate(employe);

            await this.unitOfWork.EmployRepository.Create(result);
        }

        public async Task Update(EmployeDto employe)
        {
            var result = await this.unitOfWork.EmployRepository.Get(employe.Id);
            EmployMapper.MapUpdate(result, employe);

            await this.unitOfWork.EmployRepository.Update(result);
        }

        public async Task Delete(int id)
        {
            var employe = await this.unitOfWork.EmployRepository.Get(id);

            await this.unitOfWork.EmployRepository.Delete(employe);
        }
    }
}
