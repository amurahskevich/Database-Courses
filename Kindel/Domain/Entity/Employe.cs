namespace Domain.Entity
{
    public class Employe
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsHeadOfDepartment { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int? ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
