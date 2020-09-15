using System;
using System.Collections.Generic;
using Business.Services.BookService;
using Domain.Entities;
using UI.Helpers;

namespace UI.Controllers.BookController
{
    public class BookController : IBookController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.   Просмотр всех книг.");
                Console.WriteLine("2.   Просмотр всех книг указанного автора.");
                Console.WriteLine("3.   Добавить книгу");
                Console.WriteLine("4.   Редактировать книгу");
                Console.WriteLine("5.   Удалить книгу.");
                Console.WriteLine("6.   Назад.");

                var choose = Console.ReadLine();
                var success = int.TryParse(choose, out var parseChoose);
                if (!success)
                {
                    continue;
                }

                switch (parseChoose)
                {
                    case 1:
                        this.Show();
                        break;
                    case 2:
                        this.ShowByAuthor();
                        break;
                    case 3:
                        this.Create();
                        break;
                    case 4: 
                        this.Edit();
                        break;
                    case 5:
                        this.Delete();
                        break;
                    case 6:
                        return;
                }
            }
        }

        public void Show()
        {
            Console.Clear();
            var books = bookService.GetAll();
            if (books == null || books.Count == 0)
            {
                Console.WriteLine("По данному запросу ничего не найдено. Нажмите любую кнопку для продолжения.");
                Console.ReadLine();
                return;
            }

            ShowBooks(books);
        }

        private void ShowByAuthor()
        {
            Console.Clear();
            Console.Write("Введите имя автора книги: ");
            var author = Console.ReadLine();
            var books = bookService.GetByAuthor(author);
            ShowBooks(books);
        }

        private void Create()
        {
            Console.Clear();
            Console.Write("Введите название книги: ");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите имя автора: ");
            var authorName = Console.ReadLine();
            var book = new Book
            {
                Name = name,
                Author = new Author
                {
                    Name = authorName,
                }
            };

            bookService.CreateWithAuthor(book);
        }

        public static void ShowBooks(IReadOnlyCollection<Book> books)
        {
            if (books == null || books.Count == 0)
            {
                Console.WriteLine("По данному запросу ничего не найдено. Нажмите любую кнопку для продолжения.");
                Console.ReadLine();
                return;
            }
            TableWriter.PrintLine();
            TableWriter.PrintRow("Id", "Название", "Автор");
            TableWriter.PrintLine();
            foreach (var book in books)
            {
                TableWriter.PrintRow(
                    book.Id.ToString(),
                    book.Name,
                    book.Author.Name);
            }

            TableWriter.PrintLine();
            Console.ReadLine();
        }

        private void Edit()
        {
            Console.Clear();
            Console.Write("Введите Id книги: ");
            var choose = Console.ReadLine();
            var success = int.TryParse(choose, out var parseChoose);
            if (success)
            {
                var updatedBook = this.bookService.GetById(parseChoose);
                if (updatedBook == null)
                {
                    Console.WriteLine("Книги с таким Id не существует");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Введите новое название книги: ");
                var name = Console.ReadLine();
                updatedBook.Name = name;
                this.bookService.Update(updatedBook);
            }
        }

        private void Delete()
        {
            Console.Clear();
            Console.Write("Введите Id книги: ");
            var choose = Console.ReadLine();
            var success = int.TryParse(choose, out var parseChoose);
            if (success)
            {
                this.bookService.Delete(parseChoose);
            }
        }
    }
}
