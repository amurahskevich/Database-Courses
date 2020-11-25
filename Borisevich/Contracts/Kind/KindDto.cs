using System.Collections.Generic;

namespace Contracts.Kind
{
    public class KindDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private IReadOnlyCollection<string> Animals { get; set; }
    }
}
