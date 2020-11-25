using Domain.Entity;

namespace Domain.Repositories
{
    public class KindRepository : BaseRepository<Kind>
    {
        public KindRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
