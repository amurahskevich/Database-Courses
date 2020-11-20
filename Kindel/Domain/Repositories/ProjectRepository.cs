using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Project> Get(int id)
        {
            return await this.Context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
