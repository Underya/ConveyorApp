using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NetApi
{
    /// <summary>
    /// Методы для сериализации и десериалазции объектов
    /// </summary>
    public class JSON
    {
        /// <summary>
        /// Сериализация объектов, int, int[], string, Exception
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            string res = "";
            //Получение имени типа объета
            string type = obj.GetType().Name;
            //Если тип является исключением
            if (type == "Exception")
            {
                //То сохраняет только сообщение
                res = ((Exception)(obj)).Message;
                //Тип указывается как строка
                type = "Exception";
                res = JsonSerializer.Serialize(res, res.GetType());
            }
            else 
                //Сериализация объекта
                res = JsonSerializer.Serialize(obj, obj.GetType());

            //К объекту приписывается его тип
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Type:");
            stringBuilder.Append(type);
            stringBuilder.Append(";");
            stringBuilder.Append(res);

            return Encoding.Unicode.GetBytes(stringBuilder.ToString());
        }

        public object Deserialize(byte[] serializeObj)
        {
            string str = Encoding.Unicode.GetString(serializeObj);
            //Получение типа объекта
            string type = str.Substring(str.IndexOf(':') + 1, str.IndexOf(';') - str.IndexOf(':') -1);
            //Получение объекта без типа 
            string strObject = str.Substring(str.IndexOf(';')+1, str.Length - str.IndexOf(';')-1);

            //Десериализация в зависимоти от типа
            if (type == "String")
                return JsonSerializer.Deserialize<string>(strObject);

            if (type == "Exception")
            {
                string Message = JsonSerializer.Deserialize<string>(strObject);
                return new Exception(Message);
            }

            if (type == "Int32[]")
                return JsonSerializer.Deserialize<Int32[]>(strObject);

            if (type == "Int32")
                return JsonSerializer.Deserialize<Int32>(strObject);

            //Если не шалось типа
            return JsonSerializer.Deserialize<object>(strObject);
        }

    }
}
