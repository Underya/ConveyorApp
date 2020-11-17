using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace NetApi
{
    /// <summary>
    /// Сокет для прослушивания адреса, указанного в конструкторе
    /// </summary>
    public class ListenSocket : 
        BasedSocket
    {
        /// <summary>
        /// Максимальная длина сообщения для передачи
        /// </summary>
        const int MaxSize = 10000;

        /// <summary>
        /// Максимальное число подключений
        /// </summary>
        const int MaxConnect = 100;

        /// <summary>
        /// Создания сокета для получения сообщений по указанному адресу и порту
        /// </summary>
        /// <param name="address">Адрес, который слушает сокет</param>
        /// <param name="port">Порт, который слушает сокет</param>
        public ListenSocket(string address, int port) :base(address, port)
        {
            //Подготовка сокета к прослушке
            socket.Bind(ipAdress);
            //Начала прослушивания
            //Указание максимального количества подключений
            socket.Listen(MaxConnect);
        }

        /// <summary>
        /// Делегат для обработки получаемых на сокет сообщений
        /// </summary>
        /// <param name="message"></param>
        public delegate void AcceptMessageDelegate(byte[] Message, int LengthMessage);

        /// <summary>
        /// Методы, вызываемые при получении получении сообщений
        /// </summary>
        public AcceptMessageDelegate AcceptMessage{ get; set; }

        /// <summary>
        /// Старт прослушивания сообщений. Блокирует вызывающий поток
        /// </summary>
        public void StartListen()
        {
            //Количество полученных байт
            int countByte = 0;
            byte[] data = new byte[MaxSize];

            Socket response = null;
            //Ожидание сообщения
            response = socket.Accept();
            
            do
            {
                //Получение текста сообщения
                do
                {
                    countByte = response.Receive(data);
                } while (response.Available > 0);

            } while (countByte == 0);

            //Закрытие соеденения
            response.Close();

            //Отправка сообщения слушателям
            AcceptMessage(data, countByte);
        }
    }
}
