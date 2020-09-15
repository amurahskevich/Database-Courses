using System;
using UI.Controllers.BookController;
using UI.Controllers.StudentController;

namespace UI.StartApplication
{
    public class ApplicationEntryPoint : IApplicationEntryPoint
    {
        private readonly IStudentController studentController;
        private readonly IBookController bookController;
        private bool isStarted = true;

        public ApplicationEntryPoint(IStudentController studentController, IBookController bookController)
        {
            this.studentController = studentController;
            this.bookController = bookController;
        }

        public void Start()
        {
            Menu();
        }

        private void Menu()
        {
            while (isStarted)
            {
                Console.Clear();
                Console.WriteLine("<== Информационная система библиотеки вуза ==>");
                Console.WriteLine("1.   Работа с книгами.");
                Console.WriteLine("2.   Работа со студентами.");
                Console.WriteLine("3.   Выход.");

                var choose = Console.ReadLine();
                var success = int.TryParse(choose, out var parseChoose);
                if (success)
                {
                    switch (parseChoose)
                    {
                        case 1:
                            this.bookController.Menu();
                            break;
                        case 2:
                            this.studentController.Menu();
                            break;
                        case 3:
                            this.isStarted = false;
                            break;
                    }
                }
            }
        }
    }
}
