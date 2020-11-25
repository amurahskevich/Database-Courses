using System.Collections.Generic;

namespace Contracts.Animal
{
    public class AnimalDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int KindId { get; set; }

        public int CageId { get; set; }

        public IReadOnlyCollection<int> Employes { get; set; }
    }
}
