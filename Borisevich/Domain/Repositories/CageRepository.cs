using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class CageRepository : BaseRepository<Cage>
    {
        public CageRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Cage> Get(int id)
        {
            return await this.Context.Cages.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
