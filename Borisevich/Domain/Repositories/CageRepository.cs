using Domain.Entity;

namespace Domain.Repositories
{
    public class CageRepository : BaseRepository<Cage>
    {
        public CageRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
