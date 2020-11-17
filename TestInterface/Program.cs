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
        {   SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
            ConveyorApi api = new ConveyorApi(sendSocket);

            //Меню для интерактивного теста приложения
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("G - Запрос на состояние очереди");
                Console.WriteLine("A - Добавление нового продукта");
                Console.WriteLine("D - Добавление дефективного продукта");
                Console.WriteLine("E - выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //Запрос на получение состояния сервера
                if (keyInfo.Key == ConsoleKey.G)
                {
                    try
                    {
                        int[] data = api.GetState();
                        Console.Write("Ответ:");
                        for (int i = 0; i < data.Length; i++)
                            Console.Write("{0} ", (int)data[i]);
                        Console.WriteLine("");

                    } catch(Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }

                if(keyInfo.Key == ConsoleKey.A)
                {
                    api.AddGoodProduct();
                }

                if(keyInfo.Key == ConsoleKey.D)
                {
                }

                if (keyInfo.Key == ConsoleKey.E)
                {
                    return;
                }

            }

            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }

        static void AddAnswer(SendSocket socket)
        {
            int size = -1;
            byte[] res = socket.GetAnswer(out size);
            if(size != 0)
            {
                Console.WriteLine("Ответ получен - {0}", Encoding.Unicode.GetString(res, 0, size));
            }
        }

        static byte[] ToUnicodeByte(string Message)
        {
            //Перевод в массив байтов
            return Encoding.Unicode.GetBytes(Message);
        } 
    }

}
