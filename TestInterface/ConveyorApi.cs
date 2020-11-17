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

        byte[] GetCommand = null;

        /// <summary>
        /// Создание новго АПИ для работы с конвеером
        /// </summary>
        /// <param name="SendSocket">Сокет, через который происходит связь с сервером</param>
        public ConveyorApi(SendSocket SendSocket)
        {
            sendSocket = SendSocket;
            InitialCommand();
        }

        /// <summary>
        /// Формирование списка команд
        /// </summary>
        void InitialCommand()
        {
            GetCommand = Encoding.Unicode.GetBytes("get");
        }

        /// <summary>
        /// Получение состояния конвеера на сервере
        /// </summary>
        /// <returns></returns>
        public int[] GetState()
        {
            //Запрос серверу
            sendSocket.SendMessage(GetCommand, GetCommand.Length);
            //Получение ответа
            int sizeAnswer = 0;
            byte[] answer = sendSocket.GetAnswer(out sizeAnswer);
            object answerObj = ConvertToObjThrow(answer);
            //Возвращение результатов
            return (Int32[])answerObj;
        }

        /// <summary>
        /// Десериализация объекта
        /// И проверка, явлется ли объекта исключением
        /// Если явлется, оно выбрасывается
        /// </summary>
        /// <param name="Obj"></param>
        object ConvertToObjThrow(byte[] Obj)
        {
            JSON json = new JSON();
            object AnswerObj = json.Deserialize(Obj);
            //Если объект является ошибкой, то выбрасывается исключение
            if (AnswerObj is Exception)
                throw (Exception)AnswerObj;

            //Возращение объекта
            return AnswerObj;  
        }
    }
}
