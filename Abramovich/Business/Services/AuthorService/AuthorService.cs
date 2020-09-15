using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Entities;
using Domain.EntityFramework;

namespace Business.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly UnitOfWork unitOfWork;

        public AuthorService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public IReadOnlyCollection<Author> GetAuthors()
        {
            return unitOfWork.Authors.Get().ToArray();
        }
    }
}
