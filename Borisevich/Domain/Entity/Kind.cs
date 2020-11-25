using System.Collections.Generic;

namespace Domain.Entity
{
    public class Kind
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
