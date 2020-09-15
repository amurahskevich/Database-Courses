using Domain.EntityFramework;
using Domain.Repositories;

namespace Domain
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public AuthorRepository Authors => new AuthorRepository(context);

        public BookRepository Books => new BookRepository(context);

        public StudentRepository Students => new StudentRepository(context);

        public OrderRepository Orders => new OrderRepository(context);
    }
}
