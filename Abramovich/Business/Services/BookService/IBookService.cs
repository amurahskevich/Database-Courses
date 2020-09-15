using System.Collections.Generic;
using Domain.Entities;

namespace Business.Services.BookService
{
    public interface IBookService
    {
        IReadOnlyCollection<Book> GetByAuthor(string authorName);

        IReadOnlyCollection<Book> GetAll();

        Book CreateWithAuthor(Book book);

        Book GetById(int id);

        void Update(Book book);

        void Delete(int id);
    }
}
