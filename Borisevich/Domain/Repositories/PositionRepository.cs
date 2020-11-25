namespace Domain.Repositories
{
    public class PositionRepository : BaseRepository<PositionRepository>
    {
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
