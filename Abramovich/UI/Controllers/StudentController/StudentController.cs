using System;
using System.Collections.Generic;
using System.Linq;
using Business.Services.BookService;
using Business.Services.OrderService;
using Business.Services.StudentService;
using Domain.Entities;
using UI.Helpers;

namespace UI.Controllers.StudentController
{
     public class StudentController : IStudentController
     {
         private readonly IStudentService studentService;
         private readonly IBookService bookService;
         private readonly IOrderService orderService;

         public StudentController(
             IStudentService studentService,
             IBookService bookService,
             IOrderService orderService)
         {
             this.studentService = studentService;
             this.bookService = bookService;
             this.orderService = orderService;
         }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.   Добавить студента.");
                Console.WriteLine("2.   Редактировать студента.");
                Console.WriteLine("3.   Удалить студента.");
                Console.WriteLine("4.   Просмотр всех студентов.");
                Console.WriteLine("5.   Выдать книгу студенту.");
                Console.WriteLine("6    Просмотр всех заказов студента.");
                Console.WriteLine("7.   Назад.");

                var choose = Console.ReadLine();
                var success = int.TryParse(choose, out var parseChoose);
                if (success)
                {
                    switch (parseChoose)
                    {
                        case 1:
                            this.Add();
                            break;
                        case 2:
                            this.Edit();
                            break;
                        case 3:
                            this.Delete();
                            break;
                        case 4:
                            this.Show();
                            break;
                        case 5: 
                            this.GiveOutBook();
                            break;
                        case 6:
                            this.GetOrders();
                            break;
                        case 7:
                            return;
                    }
                }
            }
        }

        private void Add()
        {
            Console.Clear();
            Console.Write("Введите имя студента: ");
            var firstName = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            var lastName = Console.ReadLine();
            var student = new Person
            {
                FirstName = firstName,
                LastName = lastName,
            };
            
            this.studentService.Create(student);
        }

        private void Edit()
        {
            Console.Clear();
            Console.Write("Введите Id студента: ");
            var id = Console.ReadLine();
            var success = int.TryParse(id, out var parseId);
            if (!success)
            {
                Console.WriteLine("Некорректно указан Id.");
                Console.ReadLine();
                return;
            }

            var student = this.studentService.GetById(parseId);
            if (student == null)
            {
                Console.WriteLine("Студента с указанным Id не существует.");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите имя студента: ");
            var firstName = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            var lastName = Console.ReadLine();

            student.FirstName = firstName;
            student.LastName = lastName;

            this.studentService.Update(student);
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Введите Id студента: ");
            var id = Console.ReadLine();
            var success = int.TryParse(id, out var parseId);
            if (!success)
            {
                Console.WriteLine("Некорректно указан Id.");
                Console.ReadLine();
                return;
            }

            this.studentService.Delete(parseId);
        }

        private void Show()
        {
            var students = this.studentService.GetAll();
            ShowStudents(students);
        }

        private void GiveOutBook()
        {
            Console.Clear();
            var students = studentService.GetAll();
            ShowStudents(students);
            Console.WriteLine();
            var books = bookService.GetAll();
            BookController.BookController.ShowBooks(books);

            Console.Write("Введите Id книги: ");
            var bookId = Console.ReadLine();
            var successBook = int.TryParse(bookId, out var parseBookId);
            Console.Write("Введите Id студента: ");
            var studentId = Console.ReadLine();
            var successStudent = int.TryParse(studentId, out var parseStudentId);
            if (!successBook || !successStudent)
            {
                Console.WriteLine("Некорректно указан Id.");
                Console.ReadLine();
                return;
            }

            this.orderService.CreateOrder(parseBookId, parseStudentId);
        }

        private void GetOrders()
        {
            Console.Clear();
            Console.Write("Введите Id студента: ");
            var id = Console.ReadLine();
            var success = int.TryParse(id, out var parseId);
            if (!success)
            {
                Console.WriteLine("Некорректно указан Id.");
                Console.ReadLine();
                return;
            }

            var strudents = studentService.GetOrdersByStudent(parseId);
            ShowStudentOrders(strudents);
        }

        private static void ShowStudents(IReadOnlyCollection<Person> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("По данному запросу ничего не найдено. Нажмите любую кнопку для продолжения.");
                Console.ReadLine();
                return;
            }
            TableWriter.PrintLine();
            TableWriter.PrintRow("Id", "Имя", "Фамилия");
            TableWriter.PrintLine();
            foreach (var student in students)
            {
                TableWriter.PrintRow(
                    student.Id.ToString(),
                    student.FirstName,
                    student.LastName);
            }

            TableWriter.PrintLine();
            Console.ReadLine();
        }

        private static void ShowStudentOrders(IReadOnlyCollection<Person> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("По данному запросу ничего не найдено. Нажмите любую кнопку для продолжения.");
                Console.ReadLine();
                return;
            }
            TableWriter.PrintLine();
            TableWriter.PrintRow("Id", "Имя", "Фамилия", "Книги");
            TableWriter.PrintLine();
            foreach (var student in students)
            {
                var orders = student.Orders.Select(x => x.BookOrders.FirstOrDefault()).ToArray();
                var books = orders.Select(x => x.Book.Name);
                var userFriendlyNames = string.Join(' ', books);
                TableWriter.PrintRow(
                    student.Id.ToString(),
                    student.FirstName,
                    student.LastName,
                    userFriendlyNames);
            }

            TableWriter.PrintLine();
            Console.ReadLine();
        }
    }
}
