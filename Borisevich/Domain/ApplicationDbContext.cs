using Domain.Entity;
using Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Employe> Employes { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Animal> Animals { get; set; }

        public virtual DbSet<Kind> Kinds { get; set; }

        public virtual DbSet<Cage> Cages { get; set; }

        public virtual DbSet<AnimalEmploye> AnimalEmployes { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalEmployeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeEntityTypeConfiguration());
        }
    }
}
