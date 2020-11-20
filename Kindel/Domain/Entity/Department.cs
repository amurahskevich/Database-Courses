using System.Collections.Generic;

namespace Domain.Entity
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employe> Employes { get; set; }
    }
}
