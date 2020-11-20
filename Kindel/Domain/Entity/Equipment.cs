namespace Domain.Entity
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
