using NetApi;
using System;
using System.Text.Json;

namespace ConveyorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            JSON json = new JSON();
            byte[] b1 = json.Serialize("text");
            byte[] b2 = json.Serialize(new Exception("excetpion text"));
            byte[] b3 = json.Serialize(new int[3] { 1, 2, 1 });
            byte[] b4 = json.Serialize(new ListenSocket("127.0.0.1", 1234));

            object o1 = json.Deserialize(b1);
            object o2 = json.Deserialize(b2);
            object o3 = json.Deserialize(b3);
            object o4 = json.Deserialize(b4);
            try
            {
                QueueConveyor queueConveyor = new QueueConveyor();
                ListenSocket listenSocket = new ListenSocket("127.0.0.1", 8001);
                ConveyorServer conveyorServer = new ConveyorServer(queueConveyor, listenSocket);
                conveyorServer.StartLisetn();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }
}
