namespace Data.Contracts.Entities
{
    public class Sms
    {
        public int Id { get; set; }

        public int NumberOfSms { get; set; }

        public int FeePerSms { get; set; }

        public int RateId { get; set; }

        public Rate Rate { get; set; }
    }
}
