namespace Data.Contracts.Entities
{
    public class HobbyClient
    {
        public int HobbyId { get; set; }

        public Hobby Hobby { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
