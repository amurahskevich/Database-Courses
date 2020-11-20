using Contracts.Employe;
using Domain.Entity;

namespace Business.Employees.Mapping
{
     public class EmployMapper
    {
        public static Employe MapCreate(EmployeDto employe)
        {
            return new Employe
            {
                FirstName = employe.FirstName,
                LastName = employe.LastName,
                Age = employe.Age,
                IsHeadOfDepartment = employe.IsManager,
                CategoryId = employe.CategoryId,
                DepartmentId = employe.DepartmentId,
                ProjectId = employe.ProjectId,
            };
        }

        public static void MapUpdate(Employe oldEmploye,EmployeDto newEmploye)
        {
            oldEmploye.FirstName = newEmploye.FirstName;
            oldEmploye.LastName = newEmploye.LastName;
            oldEmploye.Age = newEmploye.Age;
            oldEmploye.IsHeadOfDepartment = newEmploye.IsManager;
            oldEmploye.CategoryId = newEmploye.CategoryId;
            oldEmploye.DepartmentId = newEmploye.DepartmentId;
            oldEmploye.ProjectId = newEmploye.ProjectId;
        }

        public static EmployeDto Map(Employe employe)
        {
            return new EmployeDto
            {
                Id = employe.Id,
                FirstName = employe.FirstName,
                LastName = employe.LastName,
                Age = employe.Age,  
                IsManager = employe.IsHeadOfDepartment,
                CategoryId = employe.CategoryId,
                CategoryName = employe.Category?.Name ?? string.Empty,
                DepartmentId = employe.DepartmentId,
                DepartmentName = employe.Department?.Name ?? string.Empty,
                ProjectId = employe.ProjectId,
                ProjectName = employe.Project?.Name ?? string.Empty,
            };
        }
    }
}
