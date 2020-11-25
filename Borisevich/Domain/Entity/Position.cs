using System.Collections.Generic;

namespace Domain.Entity
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }
    }
}
