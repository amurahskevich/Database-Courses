using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Departments.Mapping;
using Contracts.Department;
using Domain;

namespace Business.Departments.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly UnitOfWork unitOfWork;

        public DepartmentService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<IReadOnlyCollection<DepartmentDto>> GetList()
        {
            var departments = await this.unitOfWork.DepartmentRepository.GetList();

            return departments.Select(DepartmentMapper.Map).ToArray();
        }

        public async Task<DepartmentDto> Get(int id)
        {
            var department = await this.unitOfWork.DepartmentRepository.Get(id);

            return DepartmentMapper.Map(department);
        }

        public async Task Create(DepartmentDto department)
        {
            var dep = DepartmentMapper.MapCreate(department);

            await this.unitOfWork.DepartmentRepository.Create(dep);
        }

        public async Task Update(DepartmentDto newDepartment)
        {
            var department = await this.unitOfWork.DepartmentRepository.Get(newDepartment.Id);
            DepartmentMapper.MapUpdate(department, newDepartment);

            await this.unitOfWork.DepartmentRepository.Update(department);
        }

        public async Task Delete(int id)
        {
            var department = await this.unitOfWork.DepartmentRepository.Get(id);

            await this.unitOfWork.DepartmentRepository.Delete(department);
        }
    }
}
