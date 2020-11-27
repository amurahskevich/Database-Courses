using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class PositionRepository : BaseRepository<Position>
    {
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Position> Get(int id)
        {
            return await this.Context.Positions.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
