using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>
    {
        public AnimalRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Animal> Get(int id)
        {
            return await this.Context.Animals.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
