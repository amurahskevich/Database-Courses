using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EmployeRepository : BaseRepository<Employe>
    {
        public EmployeRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Employe> Get(int id)
        {
            return await this.Context.Employes.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
