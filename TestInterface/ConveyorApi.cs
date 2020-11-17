using NetApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestInterface
{
    /// <summary>
    /// Класс, предоставляющий интерфейс для работы с конвеером
    /// </summary>
    public class ConveyorApi
    {
        /// <summary>
        /// СОкет для отправки сообщений
        /// </summary>
        SendSocket sendSocket = null;

        /// <summary>
        /// Создание новго АПИ для работы с конвеером
        /// </summary>
        /// <param name="SendSocket">Сокет, через который происходит связь с сервером</param>
        public ConveyorApi(SendSocket SendSocket)
        {

        }
    }
}
