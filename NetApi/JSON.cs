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

        /*
        public object Deserialize(byte[] serializeObj)
        {
            string str = Encoding.Unicode.GetString(serializeObj);
            return JsonSerializer.Deserialize(;
        }*/
    }
}
