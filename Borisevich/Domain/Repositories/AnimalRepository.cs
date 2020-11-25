using Domain.Entity;

namespace Domain.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>
    {
        public AnimalRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
