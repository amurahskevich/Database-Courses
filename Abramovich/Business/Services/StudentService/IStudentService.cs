using System.Collections.Generic;
using Domain.Entities;

namespace Business.Services.StudentService
{
    public interface IStudentService
    {
        IReadOnlyCollection<Person> GetAll();

        void Create(Person student);

        Person GetById(int id);

        Person GetByName(string name);

        IReadOnlyCollection<Person> GetOrdersByStudent(int id);

        void Update(Person student);

        void Delete(int id);
    }
}
