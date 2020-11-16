using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetApi
{
    public class BasedSocket
    {
        /// <summary>
        /// Объект сокета, вокруг которого происходит работа
        /// </summary>
        protected Socket socket = null;
        
        /// <summary>
        /// Адрес, с которым связан сокет
        /// </summary>
        protected IPEndPoint ipAdress = null;

        /// <summary>
        /// Создание сокета и сохранения информации о об адресе
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public BasedSocket(string address, int port)
        {
            //Сохранение инфомрации об адресе
            ipAdress = new IPEndPoint(IPAddress.Parse(address), port);
            //Создание объекта сокета
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Деструктор объекта
        /// </summary>
        ~BasedSocket()
        {
            //Уничтожение сокета
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
