using Domain.Entity;

namespace Contracts.Animal
{
    public class AnimalDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int KindId { get; set; }

        public string KindName { get; set; }

        public int CageId { get; set; }

        public int CageNumber { get; set; }

        public int[] Employes { get; set; }
    }
}
