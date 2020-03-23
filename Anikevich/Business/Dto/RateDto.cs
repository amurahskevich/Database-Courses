namespace Business.Dto
{
    public class RateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CallDto Call { get; set; }

        public SmsDto Sms { get; set; }

        public InternetDto Internet { get; set; }

        public RoamingDto Roaming { get; set; }

        public HomeInternetDto HomeInternet { get; set; }
    }
}
