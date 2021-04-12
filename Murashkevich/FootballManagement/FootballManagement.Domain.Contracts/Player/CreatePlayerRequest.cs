using System.Runtime.Serialization;

namespace FootballManagement.Domain.Contracts.Player
{
    [DataContract]
    public class CreatePlayerRequest
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "role")]
        public int Role { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "teamSystemName")]
        public string TeamSystemName { get; set; }
    }
}
