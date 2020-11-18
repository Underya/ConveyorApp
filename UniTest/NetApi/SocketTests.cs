using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NetApi;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace UniTest.NetApi
{
    [TestClass]
    public class SocketTests
    {
        string address = "127.0.0.2", address2 = "127.0.0.3",
            address3 = "127.0.0.4";
        int port = 8124, port2 =8125, port3 = 8126;


        [TestMethod]
        public void CreateListenSocket()
        {
            ListenSocket listenSocket = new ListenSocket(address, port);
        }

        [TestMethod]
        public void CreateSendSocket()
        {
            SendSocket sendSocket = new SendSocket(address, port);
        }

        [TestMethod]
        public void AddDelegate()
        {
            ListenSocket listenSocket = new ListenSocket(address2, port2);
            listenSocket.AcceptMessage += new ListenSocket.AcceptMessageDelegate((mess, lengt) => { });
        }
    
        [TestMethod]
        public void ErrorConnect()
        {
            SendSocket SendSocket = new SendSocket(address3, port3);
            try
            {
                SendSocket.SendMessage(new byte[] { 1, 2 }, 2);
            }
            catch
            {
                return;
            }

            Assert.Fail();
        }

    }
}
