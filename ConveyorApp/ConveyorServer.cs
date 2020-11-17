using System;
using System.Collections.Generic;
using System.Text;
using NetApi;

namespace ConveyorApp
{
    /// <summary>
    /// Класс для оработки и получения запросов по IP
    /// </summary>
    public class ConveyorServer
    {

        /// <summary>
        /// Указание, необходимо ли серверу продолжать работать
        /// </summary>
        bool work = false;

        /// <summary>
        /// Объект для сериализации
        /// </summary>
        JSON json = null;

        /// <summary>
        /// Конвеер с продуктами
        /// </summary>
        IConveyor conveyor = null;

        /// <summary>
        /// Сокет, с помощью которого осуществляется прослушивание
        /// </summary>
        ListenSocket listenSocket = null;

        /// <summary>
        /// Создание нового сервера, работающего с указанным сервером
        /// </summary>
        /// <param name="Conveyor"></param>
        public ConveyorServer(IConveyor Conveyor, ListenSocket ListenSocket)
        {
            ///Сохранение конвейера
            conveyor = Conveyor;
            //Созранение сокета
            listenSocket = ListenSocket;
            //Добавляется метод для прослушивания получаемых сообщений
            listenSocket.AcceptMessage += AcceptMessage;
            //СОздание объекта для сериализации
            json = new JSON();
        }

        /// <summary>
        /// Запуск прослушивания сервера 
        /// </summary>
        public void StartLisetn()
        {
            Console.WriteLine("Сервер запущен");
            //Указание, что сервер запушен
            work = true;

            while (work)
            {
                //Запуск прослушивания
                listenSocket.StartListen();
            }
        }

        /// <summary>
        /// Обработка сообщений, получаемых сервером
        /// </summary>
        /// <param name="Messagem"></param>
        /// <param name="SizeMessage"></param>
        void AcceptMessage(byte []Messagem, int SizeMessage)
        {
            Console.WriteLine("Получено сообщение");
            //Получение сообщения и его певерод в строку
            string Calling = Encoding.Unicode.GetString(Messagem, 0, SizeMessage);
            Console.WriteLine("Сообщение: {0}", Calling);
            //В зависимости от типа сообщения, вызов соотсвествующей функции разбора
            if (Calling.ToLower() == "get")
                GetCalling();
            if (Calling.ToLower().Contains("add"))
                AddNewProduct(Calling);

        }

        /// <summary>
        /// Получение запроса на состояние конееера
        /// </summary>
        void GetCalling()
        {
            //Отправка ответа
            int[] resp = conveyor.State.ToArray();
            //Сериализация
            listenSocket.SendAnswer(json.Serialize(resp));
            //Сообщение об отправки состояния
            Console.WriteLine("Отправлено состояние конвеера");
        }

        /// <summary>
        /// Запрос на добавления новых элементов в очередь
        /// </summary>
        void AddNewProduct(string Answer)
        {
            //Получение типа нового элемента
            string type = Answer.Substring(Answer.IndexOf(':') + 1);
            try
            {
                if (type == "1")
                    //Добавление нового хорошего элемента
                    conveyor.AddProduct(1);
                else if (type == "2")
                    //Добавление брака
                    conveyor.AddProduct(2);
                else
                    //Выброс ошибки, о не правильной комманде добавления
                    throw new Exception("Неправильная комманда добавления нового продукта");
            }
            catch (Exception exc)
            {
                //Отправление ошибки пользователю
                listenSocket.SendAnswer(json.Serialize(exc));
                return;
            }

            //Сообщение об успешно добавлении
            listenSocket.SendAnswer(json.Serialize("Ok"));
        }

    }
}
