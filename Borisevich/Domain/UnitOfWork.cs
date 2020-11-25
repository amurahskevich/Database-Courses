using System;
using Domain.Repositories;

namespace Domain
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context;

        public AnimalRepository Animals { get; }

        public CageRepository Cages { get; }

        public EmployeRepository Employes { get; }

        public KindRepository Kinds { get; }

        public PositionRepository Positions { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            this.Animals = new AnimalRepository(context);
            this.Cages = new CageRepository(context);
            this.Employes = new EmployeRepository(context);
            this.Kinds = new KindRepository(context);
            this.Positions = new PositionRepository(context);
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
