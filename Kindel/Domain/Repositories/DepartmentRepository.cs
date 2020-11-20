using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Department> Get(int id)
        {
            return await this.All.FirstOrDefaultAsync(p => p.Id == id);
        }

        protected override IQueryable<Department> All => this.Context.Departments
            .Include(p => p.Employes);
    }
}
