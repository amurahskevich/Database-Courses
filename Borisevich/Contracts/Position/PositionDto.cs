using System.Collections.Generic;

namespace Contracts.Position
{
    public class PositionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<string> Employes { get; set; }
    }
}
