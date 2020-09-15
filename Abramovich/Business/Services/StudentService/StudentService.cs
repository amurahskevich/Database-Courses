using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Domain.EntityFramework;

namespace Business.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork unitOfWork;

        public StudentService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public IReadOnlyCollection<Person> GetAll()
        {
            return this.unitOfWork.Students.Get();
        }

        public void Create(Person student)
        {
            this.unitOfWork.Students.Create(student);
        }

        public Person GetById(int id)
        {
            return this.unitOfWork.Students.Get(id);
        }

        public Person GetByName(string name)
        {
            return this.unitOfWork.Students.Get(name);
        }

        public IReadOnlyCollection<Person> GetOrdersByStudent(int id)
        {
            return this.unitOfWork.Students.GetOrdersByStudent(id);
        }

        public void Update(Person student)
        {
            this.unitOfWork.Students.Update(student);
        }

        public void Delete(int id)
        {
            this.unitOfWork.Students.Delete(id);
        }
    }
}
