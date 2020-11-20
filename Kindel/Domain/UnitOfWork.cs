using System;
using Domain.Repositories;

namespace Domain
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context;

        public DepartmentRepository DepartmentRepository { get; }

        public CategoryRepository CategoryRepository { get; }

        public ProjectRepository ProjectRepository { get; }

        public EmployRepository EmployRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.DepartmentRepository = new DepartmentRepository(context);
            this.CategoryRepository = new CategoryRepository(context);
            this.ProjectRepository = new ProjectRepository(context);
            this.EmployRepository = new EmployRepository(context);
        }

        public void Dispose()
        {
            this.context?.Dispose();
        }
    }
}
