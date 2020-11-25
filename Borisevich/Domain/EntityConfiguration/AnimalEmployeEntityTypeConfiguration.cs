using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class AnimalEmployeEntityTypeConfiguration : IEntityTypeConfiguration<AnimalEmploye>
    {
        public void Configure(EntityTypeBuilder<AnimalEmploye> builder)
        {
            builder.HasKey(p => new { p.AnimalId, p.EmployeId });

            builder.HasOne(p => p.Animal)
                .WithMany(d => d.AnimalEmployes)
                .HasForeignKey(p => p.AnimalId);

            builder.HasOne(p => p.Employe)
                .WithMany(d => d.AnimalEmployes)
                .HasForeignKey(p => p.EmployeId);
        }
    }
}
