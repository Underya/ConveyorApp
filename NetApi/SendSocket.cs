using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace NetApi
{
    /// <summary>
    /// Сокет для отправки сообщений на указанный адрес
    /// </summary>
    public class SendSocket :
        BasedSocket
    {
        /// <summary>
        /// Создание сокета для отправки сообщений
        /// </summary>
        /// <param name="address">Адрес, куда будут отправляться сообщения</param>
        /// <param name="port">Порт, куда будут отправляться сообщения</param>
        public SendSocket(string address, int port) : base(address, port)
        {

        }

        /// <summary>
        /// Сохранения сокета для получения ответа от сервера
        /// </summary>
        Socket answerSocket = null;

        /// <summary>
        /// Создание сокета для получения сообщений
        /// </summary>
        void GetSendSocket()
        {
            //Если есть сокет, его надо закрыть
            if(answerSocket != null)
            {
                answerSocket.Shutdown(SocketShutdown.Both);
                answerSocket.Close();
            }

            //Создание нового
            answerSocket = GetNewSoket();
            answerSocket.Connect(ipAdress);
        }

        /// <summary>
        /// Попытка соедениться с указанным адресом.
        /// В случае неудаче выбрасывается исключение
        /// </summary>
        public void Connect()
        {
            socket.Connect(ipAdress);
        }

        /// <summary>
        /// Получение ответа на запрос
        /// </summary>
        /// <returns></returns>
        public byte[] GetAnswer(out int SizeMessage)
        {
            byte[] Data = new byte[3000];
            SizeMessage = answerSocket.Receive(Data);
            return Data;
        }

        /// <summary>
        /// Отправка сообщения на указанный адрес.
        /// Перед отправкой необходимо соедениться с адресом с помощью метода Connect
        /// </summary>
        /// <param name="Message">Сообщение, которое надо отправить</param>
        /// <param name="MessageSize">Размер сообщения </param>
        /// <returns></returns>
        public bool SendMessage(byte[] Message, int MessageSize)
        {
            //СОздание нового сокета
            GetSendSocket();
            //Отправка сообщения
            int rezult = answerSocket.Send(Message);

            bool returnResult = true;

            //Если размер изначального и отправленного сообщения не совпадает
            //То отправить сообщение не удалось
            if (rezult != MessageSize)
                returnResult = false;

            //Сообщение успешно отправлено
            return returnResult;
        }

    }
}
