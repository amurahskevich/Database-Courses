using Domain.Entities;
using Domain.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        private const string SqlServer = "Server=(localdb)\\mssqllocaldb;Database=Abramovich;Trusted_Connection=True";

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookOrder> BookOrders { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookOrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        }
    }
}
