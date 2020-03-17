namespace Data.Contracts.Entities
{
    public class Internet
    {
        public int Id { get; set; }

        public int Speed { get; set; }

        public int NumberOfMegabyte { get; set; }

        public int FeePerMegabyte { get; set; }

        public int RateId { get; set; }

        public Rate Rate { get; set; }
    }
}
