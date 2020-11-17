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
    class JSON
    {
        /// <summary>
        /// Сериализация объекта 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            string res = JsonSerializer.Serialize(obj);
            return Encoding.Unicode.GetBytes(res);
        }

        /*
        public object Deserialize(byte[] serializeObj)
        {
            string str = Encoding.Unicode.GetString(serializeObj);
            return JsonSerializer.Deserialize(;
        }*/
    }
}
