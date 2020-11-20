using Domain.Entity;
using Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Employe> Employes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Equipment> Equipments { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
        }
    }
}
