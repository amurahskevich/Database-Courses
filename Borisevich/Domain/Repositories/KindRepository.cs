using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class KindRepository : BaseRepository<Kind>
    {
        public KindRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Kind> Get(int id)
        {
            return await this.Context.Kinds.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
