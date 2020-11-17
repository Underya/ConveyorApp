using NetApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorGui
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
        /// Комманда получения состоиния
        /// </summary>
        byte[] GetCommand = null;

        /// <summary>
        /// Комманда добавления хорошего продукта
        /// </summary>
        byte[] AddGoodCommand = null;

        /// <summary>
        /// Комманда добавления бракованного продукта
        /// </summary>
        byte[] AddDefectiveCommmand = null;

        /// <summary>
        /// Комманда удаления продукта с конвеера
        /// </summary>
        byte[] PushCommand = null;

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
            AddGoodCommand = Encoding.Unicode.GetBytes("add:1");
            AddDefectiveCommmand = Encoding.Unicode.GetBytes("add:2");
            PushCommand = Encoding.Unicode.GetBytes("push");
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
        /// Метод добавляет годный продукт в конвеер
        /// </summary>
        public void AddGoodProduct()
        {
            ExecuteVoidCommand(AddGoodCommand);
        }

        /// <summary>
        /// Добавление брака в конвеер
        /// </summary>
        public void AddDefectiveProduct()
        {
            ExecuteVoidCommand(AddDefectiveCommmand);
        }
        
        /// <summary>
        /// Выбросить элемент в конвеере
        /// </summary>
        public void PushProduct()
        {
            ExecuteVoidCommand(PushCommand);
        }

        /// <summary>
        /// Отправление комманды серверу. Отслеживается только ошибка
        /// </summary>
        /// <param name=""></param>
        void ExecuteVoidCommand(byte[] command)
        {
            sendSocket.SendMessage(command, command.Length);
            //Получение ответа
            int sizeAnswer = 0;
            byte[] answer = sendSocket.GetAnswer(out sizeAnswer);
            //Результат не интересен, только ощибка интеренсна
            ConvertToObjThrow(answer);
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
