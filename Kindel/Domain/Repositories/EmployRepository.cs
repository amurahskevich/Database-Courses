using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EmployRepository : BaseRepository<Employe>
    {
        public EmployRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Employe> Get(int id)
        {
            return await this.All.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyCollection<Employe>> GetListByCategory(int categoryId)
        {
            return await this.All.Where(p => p.CategoryId == categoryId).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<Employe>> GetListByDepartment(int departmentId)
        {
            return await this.All.Where(p => p.DepartmentId == departmentId).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<Employe>> GetByProject(int projectId)
        {
            return await this.All.Where(p => p.ProjectId == projectId).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<Employe>> GetDepartmentHeads()
        {
            return await this.All.Where(p => p.IsHeadOfDepartment).ToArrayAsync();

        }

        protected override IQueryable<Employe> All => this.Context.Employes
            .Include(p => p.Project)
            .Include(p => p.Category)
            .Include(p => p.Department);
    }
}
