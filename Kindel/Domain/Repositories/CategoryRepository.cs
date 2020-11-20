using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Category> Get(int id)
        {
            return await this.Context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
