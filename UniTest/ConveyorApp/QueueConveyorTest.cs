using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ConveyorApp;

namespace UniTest.ConveyorApp
{
    [TestClass]
    public class QueueConveyorTest
    {
        /// <summary>
        /// Новое максимальное количество элементов в очереди
        /// </summary>
        int max1 = 1;

        /// <summary>
        /// Не существующий тип продукта
        /// </summary>
        int error_type = -1;

        [TestMethod]
        public void Create()
        {
            QueueConveyor conveyor = new QueueConveyor();
        }

        [TestMethod]
        public void AddGoodProduct()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(1);
        }

        [TestMethod]
        public void AddDefectiveProduct()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(2);
        }

        [TestMethod]
        public void AddErrorTypeProduct()
        {
            QueueConveyor conveyor = new QueueConveyor();
            Assert.ThrowsException<InvalidCastException>(() =>
            {
                conveyor.AddProduct(error_type);
            });
            
        }

        [TestMethod]
        public void GetState()
        {
            QueueConveyor conveyor = new QueueConveyor();
            Assert.AreEqual(0, conveyor.State.Count);
        }

        [TestMethod]
        public void CheckState()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(1);
            conveyor.AddProduct(2);
            List<int> res = conveyor.State;
            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(2, res[1]);
        }

        [TestMethod]
        public void PushProduct()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(1);
            conveyor.PushProdcut();
        }

        [TestMethod]
        public void PushError()
        {
            QueueConveyor conveyor = new QueueConveyor();

            Assert.ThrowsException<Exception>(() =>
            {
                conveyor.PushProdcut();
            });
        }

        [TestMethod]
        public void PushErrorAfteePop()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(1);

            Assert.ThrowsException<Exception>(() =>
            {
                conveyor.PushProdcut();
                conveyor.PushProdcut();
            });
        }

        [TestMethod]
        public void ErrorAdd()
        {
            QueueConveyor conveyor = new QueueConveyor();
            conveyor.AddProduct(1); //1
            conveyor.AddProduct(1); //2
            conveyor.AddProduct(1); //3
            conveyor.AddProduct(1); //4
            conveyor.AddProduct(1); //5

            Assert.ThrowsException<Exception>(() =>
            {
                conveyor.AddProduct(1);
            });
        }

        [TestMethod]
        public void ChangeMaxCount()
        {
            QueueConveyor conveyor = new QueueConveyor(max1);
            
        }

        [TestMethod]
        public void CheckNewMax()
        {
            QueueConveyor conveyor = new QueueConveyor(max1);
            conveyor.AddProduct(1);
            Assert.ThrowsException<Exception>(() =>
            {
                conveyor.AddProduct(1);
            });
        }
    }
}
