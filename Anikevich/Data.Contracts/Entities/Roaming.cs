namespace Data.Contracts.Entities
{
    public class Roaming
    {
        public int Id { get; set; }

        public int NumberOfMinutes { get; set; }

        public int FeePerMinute { get; set; }

        public int RateId { get; set; }

        public Rate Rate { get; set; }
    }
}
