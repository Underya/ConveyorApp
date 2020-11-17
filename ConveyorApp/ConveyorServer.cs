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
        }

        /// <summary>
        /// Запуск прослушивания сервера 
        /// </summary>
        public void StartLisetn()
        {
            Console.WriteLine("Сервер запущен");
            //Запуск прослушивания
            listenSocket.StartListen();
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
        }

    }
}
