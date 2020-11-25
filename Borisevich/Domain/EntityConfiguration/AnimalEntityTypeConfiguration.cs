using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasOne(p => p.Kind)
                .WithMany(d => d.Animals)
                .HasForeignKey(p => p.KindId);

            builder.HasOne(p => p.Cage)
                .WithMany(d => d.Animals)
                .HasForeignKey(p => p.CageId);
        }
    }
}
