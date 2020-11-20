namespace Contracts.Employe
{
    public class EmployeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsManager { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int? ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}
