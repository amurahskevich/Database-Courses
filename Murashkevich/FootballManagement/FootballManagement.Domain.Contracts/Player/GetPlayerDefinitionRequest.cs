using System.Runtime.Serialization;
using FootballManagement.Domain.Contracts.Common;

namespace FootballManagement.Domain.Contracts.Player
{
    [DataContract]
    public class GetPlayerDefinitionRequest
    {
        [DataMember(Name = "systemName")]
        public string SystemName { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "role")]
        public ExternalReference Role { get; set; }

        [DataMember(Name = "team")]
        public ExternalReference Team { get; set; }
    }
}
