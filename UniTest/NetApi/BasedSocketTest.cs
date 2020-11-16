using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetApi;
using System.Data;
using System;

namespace UniTest.NetApi
{
    [TestClass]
    public class BasedSocketTest
    {
        string address = "127.0.0.1";
        int port = 8123;

        string error_address = "Error_address";
        int error_port = -12345;

        [TestMethod]
        public void CreateBase()
        {
            BasedSocket basedSocket = new BasedSocket(address, port);
        }

        [TestMethod]
        public void ErrorAddress()
        {
            Assert.ThrowsException<FormatException>(() => 
            {
                BasedSocket basedSocket = new BasedSocket(error_address, port);
            });
        }

        [TestMethod]
        public void ErrorPort()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                BasedSocket basedSocket = new BasedSocket(address, error_port);
            });
        }
    }
}
