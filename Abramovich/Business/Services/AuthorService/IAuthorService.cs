using System.Collections.Generic;
using Domain.Entities;

namespace Business.Services.AuthorService
{
    public interface IAuthorService
    {
        IReadOnlyCollection<Author> GetAuthors();
    }
}
