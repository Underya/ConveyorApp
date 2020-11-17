using NetApi;
using System;

namespace ConveyorApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
