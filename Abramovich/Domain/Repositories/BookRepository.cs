using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IReadOnlyCollection<Book> GetByAuthor(string authorName)
        {
            return this.All
                .Where(p => p.Author.Name.Contains(authorName))
                .ToArray();
        }

        public IReadOnlyCollection<Book> GetAll()
        {
            return All.ToArray();
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        private IQueryable<Book> All => context.Books
            .Include(x => x.Author)
            .Include(x => x.BookOrders);
    }
}
