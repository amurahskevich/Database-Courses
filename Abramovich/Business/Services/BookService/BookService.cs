using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Domain.EntityFramework;

namespace Business.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly UnitOfWork unitOfWork;

        public BookService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public IReadOnlyCollection<Book> GetByAuthor(string authorName)
        {
            return unitOfWork.Books.GetByAuthor(authorName);
        }

        public IReadOnlyCollection<Book> GetAll()
        {
            return unitOfWork.Books.GetAll();
        }

        public Book CreateWithAuthor(Book book)
        {
            var author = unitOfWork.Authors.GetByName(book.Author.Name);
            if (author == null)
            {
                var newAuthor = book.Author;
                var createdAuthor = unitOfWork.Authors.CreateNew(newAuthor);
                book.Author = null;
                book.AuthorId = createdAuthor.Id;
                unitOfWork.Books.Create(book);

                return book;
            }

            book.AuthorId = author.Id;
            book.Author = null;
            unitOfWork.Books.Create(book);

            return book;
        }

        public Book GetById(int id)
        {
            return unitOfWork.Books.Get(id);
        }

        public void Update(Book book)
        {
            this.unitOfWork.Books.Update(book);
        }

        public void Delete(int id)
        {
            this.unitOfWork.Books.Delete(id);
        }
    }
}
