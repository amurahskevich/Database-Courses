using System.Linq;
using Domain.Entities;
using Domain.EntityFramework;

namespace Domain.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Author GetByName(string name)
        {
            return context.Authors.FirstOrDefault(x => x.Name == name);
        }

        public Author CreateNew(Author author)
        {
            this.Create(author);

            return author;
        }
    }
}
