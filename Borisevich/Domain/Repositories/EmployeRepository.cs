using Domain.Entity;

namespace Domain.Repositories
{
    public class EmployeRepository : BaseRepository<Employe>
    {
        public EmployeRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
