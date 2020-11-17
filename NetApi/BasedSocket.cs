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
        }

        /// <summary>
        /// Создание нового сокета с указанным адресом
        /// </summary>
        /// <returns></returns>
        protected Socket GetNewSoket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Деструктор объекта
        /// </summary>
        ~BasedSocket()
        {
            //Если сокет существует, его надо закрыть
            if (socket != null)
            {
                //Уничтожение сокета
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}
