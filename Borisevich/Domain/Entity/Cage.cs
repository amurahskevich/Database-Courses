using System.Collections.Generic;

namespace Domain.Entity
{
    public class Cage
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
