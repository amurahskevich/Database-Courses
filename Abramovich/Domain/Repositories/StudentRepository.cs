using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class StudentRepository : BaseRepository<Person>
    {
        public StudentRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Person Get(string name)
        {
            return this.All.FirstOrDefault(x => x.LastName == name
                                                       || x.FirstName == name);
        }

        public void Update(Person student)
        {
            context.Persons.Update(student);
            context.SaveChanges();
        }

        public IReadOnlyCollection<Person> GetOrdersByStudent(int id)
        {
            return this.All.Where(x => x.Id == id).ToArray();
        }

        private IQueryable<Person> All => context.Persons
            .Include(x => x.Orders)
            .ThenInclude(p => p.BookOrders)
            .ThenInclude(x => x.Book);
    }
}
