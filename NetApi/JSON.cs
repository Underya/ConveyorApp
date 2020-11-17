using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NetApi
{
    /// <summary>
    /// Методы для сериализации и десериалазции объектов
    /// </summary>
    public class JSON
    {
        /// <summary>
        /// Сериализация объекта 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            string res = JsonSerializer.Serialize(obj, obj.GetType());
            //К объекту приписывается его тип
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Type:");
            stringBuilder.Append(obj.GetType().Name);
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
                return JsonSerializer.Deserialize<Exception>(strObject);

            if (type == "Int32[]")
                return JsonSerializer.Deserialize<Int32[]>(strObject);

            if (type == "Int32")
                return JsonSerializer.Deserialize<Int32>(strObject);

            //Если не шалось типа
            return JsonSerializer.Deserialize<object>(strObject);
        }
    }
}
