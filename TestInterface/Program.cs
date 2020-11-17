using NetApi;
using System;
using System.Text;

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
            byte[] GetMesage = ToUnicodeByte("Get");
            SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
            //Меню для интерактивного теста приложения
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("G - Запрос на состояние очереди");
                Console.WriteLine("E - выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //Запрос на получение состояния сервера
                if (keyInfo.Key == ConsoleKey.G)
                {
                    try
                    {
                        sendSocket.SendMessage(GetMesage, GetMesage.Length);
                    } catch(Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }

                if (keyInfo.Key == ConsoleKey.E)
                {
                    return;
                }

            }

            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }

        static byte[] ToUnicodeByte(string Message)
        {
            //Перевод в массив байтов
            return Encoding.Unicode.GetBytes(Message);
        } 
    }

}
