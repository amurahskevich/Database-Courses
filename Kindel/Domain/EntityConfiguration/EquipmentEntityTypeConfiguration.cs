using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasOne(p => p.Project)
                .WithMany(d => d.Equipments)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
