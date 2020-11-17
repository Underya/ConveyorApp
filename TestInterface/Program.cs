using System;

namespace TestInterface
{

    /// <summary>
    /// Тестовый проект являющийся заглушкей приложения интерфейса
    /// Используется для разработки части веб сервера приложения ConveyorApp
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //Меню для интерактивного теста приложения
            while (true)
            {
                Console.WriteLine("G - Запрос на состояние очереди");
                Console.WriteLine("E - выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                
                if(keyInfo.Key == ConsoleKey.G)
                {

                }
                if(keyInfo.Key == ConsoleKey.E)
                {
                    return;
                }

            }

            Console.WriteLine("Hello World!");
        }
    }
}
