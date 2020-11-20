using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EquipmentRepository : BaseRepository<Equipment>
    {
        public EquipmentRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Equipment> Get(int id)
        {
            return await this.Context.Equipments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyCollection<Equipment>> GetListByProject(int projectId)
        {
            return await this.Context.Equipments.Where(p => p.ProjectId == projectId).ToArrayAsync();
        }
    }
}
