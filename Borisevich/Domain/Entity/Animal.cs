using System.Collections.Generic;

namespace Domain.Entity
{
    public class Animal
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public int Sex { get; set; }

        public int KindId { get; set; }

        public virtual Kind Kind { get; set; }

        public virtual int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public virtual ICollection<AnimalEmploye> AnimalEmployes { get; set; }
    }
}
