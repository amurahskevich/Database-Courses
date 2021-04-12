using System.Runtime.Serialization;

namespace FootballManagement.Domain.Contracts.Common
{
    [DataContract]
    public class ExternalReference
    {
        [DataMember(Name = "systemName")]
        public string SystemName { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}
