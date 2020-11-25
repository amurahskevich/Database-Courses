using System.Collections.Generic;

namespace Contracts.Cage
{
    public class CageDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public IReadOnlyCollection<string> Animals { get; set; }
    }
}
