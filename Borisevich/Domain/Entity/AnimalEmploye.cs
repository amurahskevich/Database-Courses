namespace Domain.Entity
{
    public class AnimalEmploye
    {
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }

        public int EmployeId { get; set; }

        public virtual Employe Employe { get; set; }
    }
}
