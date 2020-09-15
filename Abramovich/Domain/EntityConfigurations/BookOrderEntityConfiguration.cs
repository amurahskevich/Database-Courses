using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class BookOrderEntityConfiguration : IEntityTypeConfiguration<BookOrder>
    {
        public void Configure(EntityTypeBuilder<BookOrder> builder)
        {
            builder.HasKey(sc => new { sc.BookId, sc.OrderId });

            builder.HasOne(sc => sc.Book)
                .WithMany(s => s.BookOrders)
                .HasForeignKey(sc => sc.BookId);

            builder.HasOne(sc => sc.Order)
                .WithMany(s => s.BookOrders)
                .HasForeignKey(sc => sc.OrderId);
        }
    }
}
