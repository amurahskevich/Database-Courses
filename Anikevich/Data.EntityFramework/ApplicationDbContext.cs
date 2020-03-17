using Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Anikevich;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Address)
                .WithOne(p => p.Client)
                .HasForeignKey<Address>(d => d.ClientId);

                entity.HasOne(d => d.Rate)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.RateId);

                entity.HasMany(d => d.Bonuses)
                .WithOne(p => p.Client)
                .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<HobbyClient>(entity =>
            {
                entity.HasKey(sc => new { sc.HobbyId, sc.ClientId });

                entity.HasOne(p => p.Hobby)
                .WithMany(d => d.Clients)
                .HasForeignKey(p => p.HobbyId);

                entity.HasOne(p => p.Client)
                .WithMany(d => d.Hobbies)
                .HasForeignKey(p => p.ClientId);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(p => p.Call)
                .WithOne(d => d.Rate)
                .HasForeignKey<Call>(p => p.RateId);

                entity.HasOne(p => p.Sms)
                .WithOne(d => d.Rate)
                .HasForeignKey<Sms>(p => p.RateId);

                entity.HasOne(p => p.Internet)
                .WithOne(d => d.Rate)
                .HasForeignKey<Internet>(p => p.RateId);

                entity.HasOne(p => p.Roaming)
                .WithOne(d => d.Rate)
                .HasForeignKey<Roaming>(p => p.RateId);

                entity.HasOne(p => p.HomeInternet)
                .WithOne(d => d.Rate)
                .HasForeignKey<HomeInternet>(p => p.RateId);
            });
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Bonus> Bonuses { get; set; }

        public DbSet<Call> Calls { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<HobbyClient> HobbyClients { get; set; }

        public DbSet<HomeInternet> HomeInternets { get; set; }

        public DbSet<Internet> Internets { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<Roaming> Roamings { get; set; }

        public DbSet<Sms> Sms { get; set; }
    }
}
