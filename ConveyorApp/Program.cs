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
            json.Serialize("text");
            json.Serialize(new Exception("excetpion text"));
            json.Serialize(new int[3] { 1, 2, 1 });
            return;
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
