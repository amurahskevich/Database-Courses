using Domain.Entity;

namespace Contracts.Employe
{
    public class EmployeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int Age { get; set; }

        public string PositionName { get; set; }

        public int PositionId { get; set; }

        public int[] Animals { get; set; }
    }
}
