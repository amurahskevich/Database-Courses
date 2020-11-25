using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.HasOne(p => p.Position)
                .WithMany(d => d.Employes)
                .HasForeignKey(p => p.PositionId);
        }
    }
}
