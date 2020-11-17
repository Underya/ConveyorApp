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
            byte[] AddProduct = ToUnicodeByte("Add:1");
            byte[] AddDefective = ToUnicodeByte("Add:2");
            SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
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
                        sendSocket.SendMessage(GetMesage, GetMesage.Length);
                        //Получение ответа
                        int retSize = -1;
                        byte[] data = sendSocket.GetAnswer(out retSize);
                        Console.Write("Ответ:");
                        for (int i = 0; i < retSize; i++)
                            Console.Write("{0} ", (int)data[i]);
                        Console.WriteLine("");

                    } catch(Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }

                if(keyInfo.Key == ConsoleKey.A)
                {
                    sendSocket.SendMessage(AddProduct, AddProduct.Length);
                    AddAnswer(sendSocket);
                }

                if(keyInfo.Key == ConsoleKey.D)
                {
                    sendSocket.SendMessage(AddDefective, AddDefective.Length);
                    AddAnswer(sendSocket);
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
