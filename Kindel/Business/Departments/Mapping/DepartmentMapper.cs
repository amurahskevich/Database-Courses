using System.Linq;
using Contracts.Department;
using Domain.Entity;

namespace Business.Departments.Mapping
{
    public static class DepartmentMapper
    {
        public static Department MapCreate(DepartmentDto department)
        {
            return new Department
            {
                Name = department.Name,
            };
        }

        public static void MapUpdate(Department oldDepartment, DepartmentDto newDepartment)
        {
            oldDepartment.Name = newDepartment.Name;
        }

        public static DepartmentDto Map(Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                ManagerName = department.Employes?.FirstOrDefault(employ => employ.IsHeadOfDepartment)?.LastName ?? string.Empty,
                CountOfEmployes = department.Employes?.Count ?? 0,
            };
        }
    }
}
