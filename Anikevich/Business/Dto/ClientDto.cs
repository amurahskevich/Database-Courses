namespace Business.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int RateId { get; set; }

        public RateDto Rate { get; set; }

        public AddressDto Address { get; set; }
    }
}
