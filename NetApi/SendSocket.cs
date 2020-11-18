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
        /// Создание сокета для получения сообщений
        /// </summary>
        void GetSendSocket()
        {
            //Если есть сокет, его надо закрыть
            if(socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            //Создание нового
            socket = GetNewSoket();
            Connect();
        }

        /// <summary>
        /// Попытка соедениться с указанным адресом.
        /// В случае неудаче выбрасывается исключение
        /// </summary>
        public void Connect()
        {
            
            try
            {
                socket.Connect(ipAdress);
            } catch(Exception exc)
            {
                //В случае, если не было установленно соеденение 
                //То сокет закрывается и удаляется, что бы создать новый
                socket.Close();
                socket = null;
                //Ошибка выбрасывается дальше
                throw exc;
            }
        }

        /// <summary>
        /// Получение ответа на запрос
        /// </summary>
        /// <returns></returns>
        public byte[] GetAnswer(out int SizeMessage)
        {
            byte[] Data = new byte[3000];
            SizeMessage = socket.Receive(Data);
            //Обрезка
            byte[] retData = new byte[SizeMessage];
            for (int i = 0; i < SizeMessage; i++)
                retData[i] = Data[i]; 
            return retData;
        }

        /// <summary>
        /// Отправка сообщения на указанный адрес.
        /// </summary>
        /// <param name="Message">Сообщение, которое надо отправить</param>
        /// <param name="MessageSize">Размер сообщения </param>
        /// <returns></returns>
        public bool SendMessage(byte[] Message, int MessageSize)
        {
            //СОздание нового сокета
            GetSendSocket();
            //Отправка сообщения
            int rezult = socket.Send(Message);

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
