using System.Collections.Generic;

namespace Domain.Entity
{
    public class Employe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sex { get; set; }

        public int Age { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<AnimalEmploye> AnimalEmployes { get; set; }
    }
}
